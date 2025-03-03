using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.UI
{
    public sealed class MenuInstaller : LifetimeScope
    {
        [SerializeField] private MenuView _menuView;
        [SerializeField] private MenuButtons _menuButtons;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_menuView);
            builder.RegisterInstance(_menuButtons);
            
            builder.Register<MenuPresenter>(Lifetime.Scoped)
                .AsImplementedInterfaces();
            builder.Register<MenuController>(Lifetime.Scoped)
                .AsImplementedInterfaces();
        }
    }
}