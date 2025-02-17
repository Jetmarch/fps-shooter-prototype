using FPSShooter.Gameplay.ImpactSystem;
using UnityEngine;

namespace FPSShooter.Gameplay.Projectiles
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class BulletProjectilePresenter : IProjectilePresenter
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
        
        public void Update(float deltaTime)
        {
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

        public void Hit(GameObject target, Vector3 hitPoint)
        {
            var impactVector = target.transform.position - _view.transform.position;
            ImpactUseCases.AffectTarget(target, _view.gameObject, new Impact(_config.Damage, _config.ImpulseForce, impactVector));
            
            //TODO: Call DecalManager
            // if (target.TryGetComponent<IHittable>(out var hittable))
            // {
            //     HitEffectsManager.PlayHitEffect(hittable, hitPoint);
            //     var impactParticles = Instantiate(_hitVFX.gameObject, hitPoint, Quaternion.identity);
            //     Destroy(impactParticles, 2f);
            // }
            
            _view.NotifyProjectileDestroyed();
        }

        public ProjectileType GetProjectileType()
        {
            return _config.ProjectileType;
        }
    }
}