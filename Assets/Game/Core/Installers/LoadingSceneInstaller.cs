using FPSShooter.Game.Core.Tasks;
using FPSShooter.Modules.Core.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace FPSShooter.Core.Installers
{
    public sealed class LoadingSceneInstaller : LifetimeScope
    {
        [SerializeField] private LoadingTaskConfig _loadingTaskConfig;
        
        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("Loading Scene Installer");

            builder.Register<TaskRunner>(Lifetime.Scoped)
                .WithParameter(_loadingTaskConfig.Tasks);

            builder.Register<TaskRunnerController>(Lifetime.Scoped).AsImplementedInterfaces();
        }
    }
}
