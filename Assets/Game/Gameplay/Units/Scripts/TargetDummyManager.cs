using System;
using System.Collections.Generic;
using FPSShooter.Modules.Units;
using FPSShooter.Modules.Utils;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace FPSShooter.Game.Gameplay.Units
{
    public sealed class TargetDummyManager : SerializedMonoBehaviour
    {
        [OdinSerialize] private GameObjectPool _targetsDummyPool;
        private List<UnitView> _activeTargetDummies;

        private void Start()
        {
            _targetsDummyPool.Initialize();
            _activeTargetDummies = new List<UnitView>();
        }

        public UnitView GetTargetDummy()
        {
            var go = _targetsDummyPool.GetObject();
            if (!go)
            {
                throw new NullReferenceException("Target dummy could not be retrieved.");
            }

            if (!go.TryGetComponent(out UnitView unitView))
            {
                throw new NullReferenceException("Target dummy prefab does not contain a component of type UnitView.");
            }
            _activeTargetDummies.Add(unitView);
            return unitView;
        }

        public void ReturnTargetDummy(UnitView unitView)
        {
            _activeTargetDummies.Remove(unitView);
            _targetsDummyPool.ReturnObject(unitView.gameObject);
        }

        public List<UnitView> GetActiveTargetDummies()
        {
            return _activeTargetDummies;
        }

        public void ReturnAllActiveTargetDummies()
        {
            foreach (var unit in _activeTargetDummies)
            {
                _targetsDummyPool.ReturnObject(unit.gameObject);
            }
            
            _activeTargetDummies.Clear();
        }
    }
}