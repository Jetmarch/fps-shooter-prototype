using System.Collections.Generic;
using FPSShooter.Modules.Gameplay.Impact;
using FPSShooter.Modules.Units;
using UnityEngine;

namespace FPSShooter.Game.Gameplay.Units
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class RespawnButtonPresenter : IUnitPresenter
    {
        private readonly float _respawnEnemiesCooldown;
        private readonly TargetDummyRespawner _targetDummyRespawner;

        public RespawnButtonPresenter(TargetDummyRespawner targetDummyRespawner)
        {
            _targetDummyRespawner = targetDummyRespawner;
        }
        
        public void Affect(ImpactData impactData)
        {
            //Not used
            //_enemySpawner.RespawnEnemies();
            Debug.Log("Respawn enemies");
            _targetDummyRespawner.RespawnDummies();
        }

        public T GetLogic<T>() where T : IUnitMechanics
        {
            throw new System.NotImplementedException();
        }

        public void AddLogic(IUnitMechanics mechanics)
        {
            throw new System.NotImplementedException();
        }

        public List<IUnitMechanics> UnitMechanics { get; }
    }
}