using System;
using FPSShooter.Modules.Gameplay.Impact;
using FPSShooter.Modules.Gameplay.Projectiles;
using FPSShooter.Modules.Units;
using UnityEngine;

namespace FPSShooter.Game.Gameplay.Projectiles
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class ProjectileAffectTargetMechanic : IAffectTargetMechanic
    {
        public event Action NotifyTargetAffectEnd;
        public event Action<GameObject> NotifyAffectTarget;
        
        private readonly UnitView _view;
        private readonly ProjectileConfig _config;

        public ProjectileAffectTargetMechanic(UnitView view, ProjectileConfig config)
        {
            _view = view;
            _config = config;
        }
        public void AffectTarget(Collision other)
        {
            var hitPoint = other.contacts[0].point;
            var hitNormal = other.contacts[0].normal;
            var impactVector = other.transform.position - _view.transform.position;
            var impactData = new ImpactData(_config.Damage, _config.ImpulseForce, impactVector, hitPoint,
                Quaternion.LookRotation(hitPoint, hitNormal));
            ImpactUseCases.AffectTarget(other.gameObject, _view.gameObject, impactData);
            
            NotifyAffectTarget?.Invoke(other.gameObject);
            NotifyTargetAffectEnd?.Invoke();
        }
    }

    public interface IAffectTargetMechanic : IUnitMechanic
    {
        event Action<GameObject> NotifyAffectTarget;
        event Action NotifyTargetAffectEnd;
        void AffectTarget(Collision other);
    }
        
}