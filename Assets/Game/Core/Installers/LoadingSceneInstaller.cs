using FPSShooter.Game.Core.Tasks;
using FPSShooter.Modules.Core.Tasks;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

namespace FPSShooter.Core.Installers
{
    public sealed class LoadingSceneInstaller : LifetimeScope
    {
        [SerializeField] private LoadingTaskConfig _loadingTaskConfig;
        [SerializeField] private Image _backgroundFadeImage;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_backgroundFadeImage);
            builder.Register<TaskRunner>(Lifetime.Scoped)
                .WithParameter(_loadingTaskConfig);

            builder.Register<TaskRunnerController>(Lifetime.Scoped).AsImplementedInterfaces();
        }
    }
}
