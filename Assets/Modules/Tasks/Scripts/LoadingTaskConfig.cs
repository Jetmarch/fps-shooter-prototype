using System.Collections.Generic;
using Sirenix.Serialization;
using UnityEngine;
using VContainer;
using SerializedScriptableObject = Sirenix.OdinInspector.SerializedScriptableObject;

namespace FPSShooter.Modules.Core.Tasks
{
    [CreateAssetMenu(fileName = "LoadingTaskConfig", menuName = "FPS Shooter/System/LoadingTaskConfig")]
    public sealed class LoadingTaskConfig : SerializedScriptableObject
    {
        [OdinSerialize] private List<IAsyncTask> _tasks;
        
        public List<IAsyncTask> Tasks => _tasks;
    }
}