using System;
using FPSShooter.Modules.Core.Tasks;
using VContainer;
// ReSharper disable InconsistentNaming

namespace FPSShooter.Game.Core.SaveLoaders
{
    [Serializable]
    public class SaveLoadTasks
    {
        public TaskRunnerConfig SavePipeline;
        public TaskRunnerConfig LoadPipeline;
    }
    
    public sealed class SaveLoadPipeline : ISaveLoadPipeline
    {
        private readonly SaveLoadTasks _saveLoadTasks;
        private readonly IObjectResolver _objectResolver;

        public SaveLoadPipeline(SaveLoadTasks saveLoadTasks, IObjectResolver objectResolver)
        {
            _saveLoadTasks = saveLoadTasks;
            _objectResolver = objectResolver;
        }

        public void Save()
        {
            var taskRunner = new TaskRunner(_saveLoadTasks.SavePipeline, _objectResolver);
            taskRunner.RunTasks();
        }

        public void Load()
        {
            var taskRunner = new TaskRunner(_saveLoadTasks.LoadPipeline, _objectResolver);
            taskRunner.RunTasks();
        }
    }

    public interface ISaveLoadPipeline
    {
        public void Save();
        public void Load();
    }
}