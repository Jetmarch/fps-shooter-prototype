using System;
using FPSShooter.Modules.Gameplay.Impact;
using UnityEngine;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Units
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class RespawnDummiesOnAffect : IInitializable, IDisposable
    {
        private readonly TargetDummyRespawner _targetDummyRespawner;
        private readonly ImpactAffectMechanics _impactAffectMechanics;
        
        public RespawnDummiesOnAffect(TargetDummyRespawner targetDummyRespawner, ImpactAffectMechanics impactAffectMechanics)
        {
            _targetDummyRespawner = targetDummyRespawner;
            _impactAffectMechanics = impactAffectMechanics;
        }

        public void Initialize()
        {
            _impactAffectMechanics.OnImpact += OnImpact;
        }

        public void Dispose()
        {
            _impactAffectMechanics.OnImpact -= OnImpact;
        }

        private void OnImpact(GameObject _, ImpactData __)
        {
            _targetDummyRespawner.RespawnDummies();
        }
    }
}