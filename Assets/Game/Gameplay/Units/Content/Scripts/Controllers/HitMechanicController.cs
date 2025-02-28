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
        private readonly ImpactAffectMechanic _impact;
        private readonly UnitHitMechanic _unitHitMechanic;

        public HitMechanicController(ImpactAffectMechanic impact, UnitHitMechanic unitHitMechanic)
        {
            _impact = impact;
            _unitHitMechanic = unitHitMechanic;
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
            _unitHitMechanic.Hit(data);
        }
    }
}