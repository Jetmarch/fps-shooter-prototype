using System;
using FPSShooter.Core.Managers;
using FPSShooter.Gameplay.ImpactSystem;
using UnityEngine;

namespace FPSShooter.Gameplay.Projectiles
{
    public sealed class Projectile : MonoBehaviour, IFixedUpdateListener
    {
        public event Action<Projectile> OnProjectileDestroyed;

        [SerializeField] private ParticleSystem _moveVFX;
        [SerializeField] private ParticleSystem _hitVFX;
        
        [SerializeField] private ProjectileConfig _projectileConfig;
        [SerializeField] private Vector3 _velocity;
        [SerializeField] private Rigidbody _rigidbody;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Initialize()
        {
            _rigidbody.mass = _projectileConfig.Mass;
            _rigidbody.drag = _projectileConfig.Drag;
            _rigidbody.velocity = transform.forward * _projectileConfig.InitialSpeed;
            _moveVFX.Play();
        }
        
        public void OnFixedUpdate(float deltaTime)
        {
            _velocity = _rigidbody.velocity;
            // Кастомное сопротивление (ρ * v² * C_d * A / 2)
            float dragForce = 0.5f * Ballistics.AirDensity * _velocity.sqrMagnitude * Ballistics.DragCoefficient * Ballistics.Area;
            _rigidbody.AddForce(-_velocity.normalized * dragForce);
            
            _rigidbody.AddForce(Physics.gravity * _projectileConfig.GravityMultiplier, ForceMode.Acceleration);

            if (_rigidbody.velocity.sqrMagnitude <= 0f)
            {
                Debug.Log($"Projectile destroyed");
                OnProjectileDestroyed?.Invoke(this);
            }
        }
        
        private void OnCollisionEnter(Collision other)
        {
            var impactVector = other.gameObject.transform.position - transform.position;
            ImpactUseCases.AffectTarget(other.gameObject, gameObject, new Impact(_projectileConfig.Damage, _projectileConfig.ImpulseForce, impactVector));
            
            _hitVFX.Play();
            
            var impactParticles = Instantiate(_hitVFX.gameObject, other.contacts[0].point, Quaternion.identity);
            Destroy(impactParticles, 2f);
            OnProjectileDestroyed?.Invoke(this);
        }
    }

    public static class Ballistics
    {
        public const float AirDensity = 1.225f; 
        public const float DragCoefficient = 0.3f; 
        public const float Area = 0.0001f;
    }
}