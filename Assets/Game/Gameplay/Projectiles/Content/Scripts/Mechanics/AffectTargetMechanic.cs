using System;
using FPSShooter.Modules.Gameplay.Impact;
using FPSShooter.Modules.Gameplay.Projectiles;
using FPSShooter.Modules.Units;
using UnityEngine;

namespace FPSShooter.Game.Gameplay.Projectiles
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class AffectTargetMechanic : IUnitMechanic
    {

        public event Action<GameObject> NotifyAffectTarget;
        
        private readonly UnitView _view;
        private readonly ProjectileConfig _config;

        public AffectTargetMechanic(UnitView view, ProjectileConfig config)
        {
            _view = view;
            _config = config;
        }
        public void AffectTarget(Collision other)
        {
            var hitPoint = other.contacts[0].point;
            var hitNormal = other.contacts[0].normal;
            var impactVector = other.transform.position - _view.transform.position;
            ImpactUseCases.AffectTarget(other.gameObject, _view.gameObject, new ImpactData(_config.Damage, _config.ImpulseForce, impactVector, hitPoint, Quaternion.LookRotation(hitPoint, hitNormal)));
            
            // _view.NotifyHitObject(other.gameObject);
            NotifyAffectTarget?.Invoke(other.gameObject);
            // _view.NotifyProjectileDestroyed();
        }
    }
}