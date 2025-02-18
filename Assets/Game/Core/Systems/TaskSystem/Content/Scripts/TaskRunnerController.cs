using FPSShooter.Modules.Core.Tasks;
using VContainer.Unity;

namespace FPSShooter.Game.Core.Tasks
{
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