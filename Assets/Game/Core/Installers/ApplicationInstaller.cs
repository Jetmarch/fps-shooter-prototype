using FPSShooter.Core.Systems;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace FPSShooter.Core.Installers
{
    public sealed class ApplicationInstaller : LifetimeScope
    {
        [SerializeField] private InputConfig _inputConfig;
        
        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("Application Installer");
            ConfigureInputSystem(builder);
        }

        private void ConfigureInputSystem(IContainerBuilder builder)
        {
            builder.RegisterInstance(_inputConfig);
            builder.Register<InputSystem>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();
        }
    }
   
}
