using System.Collections.Generic;
using Sirenix.Serialization;
using UnityEngine;
using SerializedScriptableObject = Sirenix.OdinInspector.SerializedScriptableObject;

namespace FPSShooter.Modules.Core.Tasks
{
    [CreateAssetMenu(fileName = "TaskRunnerConfig", menuName = "FPS Shooter/System/TaskRunnerConfig")]
    public sealed class TaskRunnerConfig : SerializedScriptableObject
    {
        [OdinSerialize] private List<IAsyncTask> _tasks;
        
        public List<IAsyncTask> Tasks => _tasks;
    }
}