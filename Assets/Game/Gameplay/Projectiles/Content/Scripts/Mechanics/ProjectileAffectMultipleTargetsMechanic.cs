using System;
using FPSShooter.Modules.Gameplay.Impact;
using FPSShooter.Modules.Gameplay.Projectiles;
using FPSShooter.Modules.Units;
using UnityEngine;

namespace FPSShooter.Game.Gameplay.Projectiles
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class ProjectileAffectMultipleTargetsMechanic : IAffectTargetMechanic
    {
        public event Action<GameObject> NotifyAffectTarget;
        public event Action NotifyTargetAffectEnd;

        private readonly UnitView _view;
        private readonly ProjectileConfig _config;

        public ProjectileAffectMultipleTargetsMechanic(UnitView view, ProjectileConfig config)
        {
            _view = view;
            _config = config;
        }
        public void AffectTarget(Collision other)
        {
            var hitPoint = other.contacts[0].point;
            var hitNormal = other.contacts[0].normal;
            var impactVector = other.transform.position - _view.transform.position;

            var affectedTarges = new Collider[_config.MaxAffectedTargets];
            var countOfAffectedTargets = Physics.OverlapSphereNonAlloc(_view.gameObject.transform.position,
                _config.AffectRadius, affectedTarges);
            for (var i = 0; i < countOfAffectedTargets; i++)
            {
                var impactData = new ImpactData(_config.Damage, _config.ImpulseForce, impactVector, hitPoint,
                    Quaternion.LookRotation(hitPoint, hitNormal));
                ImpactUseCases.AffectTarget(affectedTarges[i].gameObject, _view.gameObject, impactData);
                NotifyAffectTarget?.Invoke(other.gameObject);
            }
            NotifyTargetAffectEnd?.Invoke();
        }
    }
}