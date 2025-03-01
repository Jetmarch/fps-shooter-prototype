using System;
using FPSShooter.Modules.CurrencyStorage;
using FPSShooter.Modules.Meta.Upgrades;
using FPSShooter.Modules.Meta.Upgrades.Presenters;
using FPSShooter.Modules.Meta.Upgrades.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace FPSShooter.Game.Meta.Upgrades.Scripts.Installers
{
    public sealed class WeaponUpgradeListInstaller : LifetimeScope
    {
        [Header("Upgrades")]
        [SerializeField] private UpgradeConfigBundle _upgradeConfigBundle;
        [SerializeField] private UpgradePanelList _upgradePanelList;
        [SerializeField] private Transform _panelContainer;
        [SerializeField] private UpgradePanel _panelPrefab;
        
        protected override void Configure(IContainerBuilder builder)
        {
            // ConfigureUpgrades(builder);
            // ConfigureUpgradesUI(builder);
            //
            // builder.Register<MoneyStorage>(Lifetime.Scoped).AsImplementedInterfaces();
        }
        
        // private void ConfigureUpgrades(IContainerBuilder builder)
        // {
        //     builder.RegisterInstance(_upgradeConfigBundle);
        //     builder.Register<UpgradeManager>(Lifetime.Scoped);
        //     builder.Register<UpgradeConfigFactory>(Lifetime.Scoped);
        //
        //     // foreach (var upgradeConfig in _upgradeConfigs)
        //     // {
        //     //     builder.RegisterInstance(upgradeConfig).As<UpgradeConfig>();
        //     // }
        // }
        //
        // private void ConfigureUpgradesUI(IContainerBuilder builder)
        // {
        //     builder.Register<UpgradeListPresenter>(Lifetime.Scoped).AsImplementedInterfaces();
        //     builder.RegisterInstance(_upgradePanelList);
        //
        //     builder.Register<UpgradePanelFactory>(Lifetime.Scoped)
        //         .WithParameter(_panelContainer)
        //         .WithParameter(_panelPrefab);
        // }
    }
    
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class MoneyStorage : ICurrencyStorage
    {
        public void Get(int amount)
        {
            OnAmountChanged?.Invoke();
        }

        public int Amount => 99999;
        public event Action OnAmountChanged;
    }
}