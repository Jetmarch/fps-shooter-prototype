using FPSShooter.Modules.Core.GameLoop;
using FPSShooter.Modules.Gameplay.Impact;
using FPSShooter.Modules.Gameplay.Projectiles;
using UnityEngine;

namespace FPSShooter.Game.Gameplay.Projectiles
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class BulletProjectilePresenter : IProjectilePresenter, IFixedUpdateListener
    {
        private readonly ProjectileView _view;
        private readonly ProjectileConfig _config;

        private Vector3 _velocity;

        public BulletProjectilePresenter(ProjectileView view, ProjectileConfig config)
        {
            _view = view;
            _config = config;
        }

        public void Initialize()
        {
            _view.PlayMoveVFX();
            _view.Rigidbody.mass = _config.Mass;
            _view.Rigidbody.drag = _config.Drag;
            _view.Rigidbody.velocity = _view.transform.forward * _config.InitialSpeed;
        }

        public void Hit(Collision other)
        {
            var hitPoint = other.contacts[0].point;
            var hitNormal = other.contacts[0].normal;
            var impactVector = other.transform.position - _view.transform.position;
            ImpactUseCases.AffectTarget(other.gameObject, _view.gameObject, new ImpactData(_config.Damage, _config.ImpulseForce, impactVector, hitPoint, Quaternion.LookRotation(hitPoint, hitNormal)));
            
            _view.NotifyHitObject(other.gameObject);
            _view.NotifyProjectileDestroyed();
        }

        public ProjectileType GetProjectileType()
        {
            return _config.ProjectileType;
        }

        public void OnFixedUpdate(float deltaTime)
        {
            if (!_view.gameObject.activeSelf) return;
            //TODO: simplify
            _velocity = _view.Rigidbody.velocity;
            // Кастомное сопротивление (ρ * v² * C_d * A / 2)
            float dragForce = 0.5f * Ballistics.AirDensity * _velocity.sqrMagnitude * Ballistics.DragCoefficient * Ballistics.Area;
            _view.Rigidbody.AddForce(-_velocity.normalized * dragForce);
            
            _view.Rigidbody.AddForce(Physics.gravity * _config.GravityMultiplier, ForceMode.Acceleration);

            if (_view.Rigidbody.velocity.sqrMagnitude <= 0f)
            {
                Debug.Log($"Projectile destroyed");
                _view.NotifyProjectileDestroyed();
            }
        }
    }
}