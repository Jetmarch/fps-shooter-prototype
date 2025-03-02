using FPSShooter.Game.Core.Tasks;
using FPSShooter.Modules.Core.Tasks;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

namespace FPSShooter.Core.Installers
{
    public sealed class LoadingSceneInstaller : LifetimeScope
    {
        [FormerlySerializedAs("_loadingTaskConfig")] [SerializeField] private TaskRunnerConfig _taskRunnerConfig;
        [SerializeField] private Image _backgroundFadeImage;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_backgroundFadeImage);
            builder.Register<TaskRunner>(Lifetime.Scoped)
                .WithParameter(_taskRunnerConfig);

            builder.Register<TaskRunnerController>(Lifetime.Scoped).AsImplementedInterfaces();
        }
    }
}
