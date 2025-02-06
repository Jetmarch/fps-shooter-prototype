using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace FPSShooter.Core
{
    public class ApplicationInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("Application Installer");
        }
    }
}
