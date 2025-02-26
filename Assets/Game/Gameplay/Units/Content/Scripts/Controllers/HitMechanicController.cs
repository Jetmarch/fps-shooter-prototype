using System;
using FPSShooter.Game.Gameplay.Units.UnitLogic;
using FPSShooter.Modules.Gameplay.Impact;
using UnityEngine;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Units
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class HitMechanicController : IInitializable, IDisposable
    {
        private readonly ImpactAffectMechanics _impact;
        private readonly HitMechanic _hitMechanic;

        public HitMechanicController(ImpactAffectMechanics impact, HitMechanic hitMechanic)
        {
            _impact = impact;
            _hitMechanic = hitMechanic;
        }

        public void Initialize()
        {
            _impact.OnImpact += OnImpact;
        }

        public void Dispose()
        {
            _impact.OnImpact -= OnImpact;
        }
        
        private void OnImpact(GameObject affector, ImpactData data)
        {
            _hitMechanic.Hit(data);
        }
    }
}