using System;
using FPSShooter.Core.Managers;
using UnityEngine;

namespace FPSShooter.Gameplay.Projectiles
{
    public sealed class Projectile : MonoBehaviour, IFixedUpdateListener
    {
        public event Action<Projectile> OnProjectileDestroyed;

        [SerializeField] private ParticleSystem _moveVFX;
        [SerializeField] private ParticleSystem _hitVFX;
        
        [Header("Ballistics")]
        public float _initialSpeed = 800f; 
        public float _mass = 0.01f;        
        public float _drag = 0.1f;        
        public float _gravityMultiplier = 1f; 
        public Vector3 _velocity;
        private Rigidbody _rigidbody;
        // public float _damageSphereArea = 1f;
        // public int _maxAffectedDamageables = 16;
        
        
        // [SerializeField] private Collider[] _damageables;
        // private int _countOfDamageables;
        
        
        private const float AirDensity = 1.225f; 
        private const float DragCoefficient = 0.3f; 
        private const float Area = 0.0001f;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Initialize()
        {
            _rigidbody.mass = _mass;
            _rigidbody.drag = _drag;
            _rigidbody.velocity = transform.forward * _initialSpeed;
            // _damageables = new Collider[_maxAffectedDamageables];
            _moveVFX.Play();
        }
        
        public void OnFixedUpdate(float deltaTime)
        {
            _velocity = _rigidbody.velocity;
            // Кастомное сопротивление (ρ * v² * C_d * A / 2)
            float dragForce = 0.5f * AirDensity * _velocity.sqrMagnitude * DragCoefficient * Area;
            _rigidbody.AddForce(-_velocity.normalized * dragForce);
            
            _rigidbody.AddForce(Physics.gravity * _gravityMultiplier, ForceMode.Acceleration);

            if (_rigidbody.velocity.sqrMagnitude <= 0f)
            {
                Debug.Log($"Projectile destroyed");
                OnProjectileDestroyed?.Invoke(this);
            }
        }
        
        private void OnCollisionEnter(Collision other)
        {
            // if (other.collider.TryGetComponent<BodyPart>(out var targetBodyPart))
            // {
            //     targetBodyPart.Hit(this, other);
            // }
            
            //TODO: find the way to not apply splash damage to already hitted enemy
            // _countOfDamageables = Physics.OverlapSphereNonAlloc(other.contacts[0].point, _damageSphereArea, _damageables);
            // for (int i = 0; i < _countOfDamageables; i++)
            // {
            //     if (_damageables[i].TryGetComponent<BodyPart>(out var bodyPart))
            //     {
            //         bodyPart.Splash(this, other);
            //     }
            // }
            Debug.Log($"Collision with {other.gameObject.name}. Projectile destroyed");
            _hitVFX.Play();
            OnProjectileDestroyed?.Invoke(this);
        }
    }
    
    public enum ProjectileType
    {
        Bullet,
        Rocket
    }
}