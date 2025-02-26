using System;
using FPSShooter.Modules.Gameplay.Impact;
using UnityEngine;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Units
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class RespawnDummiesController : IInitializable, IDisposable
    {
        private readonly TargetDummyRespawner _targetDummyRespawner;
        private readonly ImpactAffectMechanic _impactAffectMechanic;
        
        public RespawnDummiesController(TargetDummyRespawner targetDummyRespawner, ImpactAffectMechanic impactAffectMechanic)
        {
            _targetDummyRespawner = targetDummyRespawner;
            _impactAffectMechanic = impactAffectMechanic;
        }

        public void Initialize()
        {
            _impactAffectMechanic.OnImpact += OnImpact;
        }

        public void Dispose()
        {
            _impactAffectMechanic.OnImpact -= OnImpact;
        }

        private void OnImpact(GameObject _, ImpactData __)
        {
            _targetDummyRespawner.RespawnDummies();
        }
    }
}