using System.Collections.Generic;
using FPSShooter.Modules.Units;
using UnityEngine;

namespace FPSShooter.Game.Gameplay.Units
{
    public sealed class TargetDummyRespawner
    {
        private readonly TargetDummyManager _targetDummyManager;
        private readonly List<UnitView> _activeDummies;
        private readonly Transform[] _spawnPoints;

        public TargetDummyRespawner(TargetDummyManager targetDummyManager, Transform[] spawnPoints)
        {
            _targetDummyManager = targetDummyManager;
            _activeDummies = new List<UnitView>();
            _spawnPoints = spawnPoints;
        }
        
        public void RespawnDummies()
        {
            KillAllDummies();
            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                var respawnedDummy = _targetDummyManager.GetTargetDummy();
                respawnedDummy.transform.position = _spawnPoints[i].position;
                respawnedDummy.transform.rotation = _spawnPoints[i].rotation;
                respawnedDummy.Resurrect();
                _activeDummies.Add(respawnedDummy);
            }
        }

        public void KillAllDummies()
        {
            for (int i = 0; i < _activeDummies.Count; i++)
            {
                _activeDummies[i].SimpleDeath();
                _targetDummyManager.ReturnTargetDummy(_activeDummies[i]);
            }
            _activeDummies.Clear();
        }
    }
}