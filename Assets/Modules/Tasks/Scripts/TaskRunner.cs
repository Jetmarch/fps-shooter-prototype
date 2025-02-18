using System.Collections.Generic;
using UnityEngine;

namespace FPSShooter.Modules.Core.Tasks
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class TaskRunner
    {
        private readonly List<IAsyncTask> _tasks;
        
        public TaskRunner(List<IAsyncTask> tasks)
        {
            _tasks = tasks;
        }
        
        public async void RunTasks()
        {
            foreach (var task in _tasks)
            {
                Debug.Log($"Running task {task.GetType().FullName}");
                await task.ExecuteAsync();
                Debug.Log($"Finished task {task.GetType().FullName}");
            }
        }

    }
}