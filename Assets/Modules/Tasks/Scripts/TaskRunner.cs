using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace FPSShooter.Modules.Core.Tasks
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class TaskRunner
    {
        private readonly List<IAsyncTask> _tasks;
        private readonly IObjectResolver _resolver;
        
        public TaskRunner(LoadingTaskConfig config, IObjectResolver resolver)
        {
            _tasks = config.Tasks;
            _resolver = resolver;
        }
        
        public async void RunTasks()
        {
            foreach (var task in _tasks)
            {
                Debug.Log($"Running task {task.GetType().FullName}");
                await ExecuteTask(task);
                Debug.Log($"Finished task {task.GetType().FullName}");
            }
        }

        private async UniTask ExecuteTask(IAsyncTask task)
        {
            _resolver.Inject(task);
            await task.ExecuteAsync();
        }
    }
}