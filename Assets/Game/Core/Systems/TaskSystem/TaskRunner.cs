using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

namespace FPSShooter.Core.Systems.TaskSystem
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class TaskRunner : IInitializable
    {
        private readonly List<IAsyncTask> _tasks;
        
        public TaskRunner(List<IAsyncTask> tasks)
        {
            _tasks = tasks;
        }

        public void Initialize()
        {
            RunTasks();
        }
        
        private async void RunTasks()
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