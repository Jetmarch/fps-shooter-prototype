using System;
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

        private void Start()
        {
            _targetsDummyPool.Initialize();
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
            
            return unitView;
        }

        public void ReturnTargetDummy(UnitView unitView)
        {
            _targetsDummyPool.ReturnObject(unitView.gameObject);
        }
    }
}