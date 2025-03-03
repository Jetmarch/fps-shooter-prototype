using FPSShooter.Modules.Core.Tasks;
using VContainer.Unity;

namespace FPSShooter.Game.Core.Tasks
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class TaskRunnerController : IInitializable
    {
        private readonly TaskRunner _taskRunner;
        
        public TaskRunnerController(TaskRunner taskRunner)
        {
            _taskRunner = taskRunner;
        }
        
        public void Initialize()
        {
            _taskRunner.RunTasks();
        }
    }
}