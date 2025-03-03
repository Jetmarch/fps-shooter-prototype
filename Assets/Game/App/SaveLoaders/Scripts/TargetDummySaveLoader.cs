using System;
using System.Collections.Generic;
using FPSShooter.Game.Gameplay.Units;
using FPSShooter.Game.Gameplay.Units.UnitLogic;
using FPSShooter.Modules.Units;
using HomeworkSaveLoad.SaveSystem;
using UnityEngine;

namespace FPSShooter.Game.Core.SaveLoaders
{
    public sealed class TargetDummyData
    {
        public Vector3 Position;
        public Vector3 Rotation;
        public int CurrentHealth;
    }
    
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class TargetDummySaveLoader : SaveLoader<IEnumerable<TargetDummyData>, TargetDummyManager>
    {
        protected override void SetupData(TargetDummyManager service, IEnumerable<TargetDummyData> data)
        {
            service.ReturnAllActiveTargetDummies();
            foreach (var unitData in data)
            {
                var targetDummy = service.GetTargetDummy();
                SetupTargetDummy(targetDummy, unitData);
            }
        }

        private void SetupTargetDummy(UnitView targetDummy, TargetDummyData data)
        {
            targetDummy.transform.position = data.Position;
            targetDummy.transform.rotation = Quaternion.Euler(data.Rotation);
            
            var objectStateMechanic = targetDummy.GetMechanic<ObjectStateMechanic>();
            if (objectStateMechanic == null)
            {
                throw new NullReferenceException("TargetDummySaveLoader: Object state mechanic component is missing on target dummy prefab.");
            }
            
            var resurrectMechanic = targetDummy.GetMechanic<ResurrectMechanic>();
            if (resurrectMechanic == null)
            {
                throw new NullReferenceException("TargetDummySaveLoader: Resurrect mechanic component is missing on target dummy prefab.");
            }

            resurrectMechanic.ResurrectWithoutNotify();
            objectStateMechanic.CurrentHealth = data.CurrentHealth;
        }

        protected override IEnumerable<TargetDummyData> ConvertToData(TargetDummyManager targetDummyManager)
        {
            var targetDummies = new List<TargetDummyData>();
            var activeTargetDummies = targetDummyManager.GetActiveTargetDummies();

            foreach (var targetDummy in activeTargetDummies)
            {
                var objectStateMechanic = targetDummy.GetMechanic<ObjectStateMechanic>();
                if (objectStateMechanic == null)
                {
                    throw new NullReferenceException("TargetDummySaveLoader: Object state mechanic component is missing on target dummy prefab.");
                }
                
                var data = new TargetDummyData()
                {
                    Position = targetDummy.transform.position,
                    Rotation = targetDummy.transform.rotation.eulerAngles,
                    CurrentHealth = objectStateMechanic.CurrentHealth
                };
                targetDummies.Add(data);
            }

            return targetDummies;
        }
    }
}