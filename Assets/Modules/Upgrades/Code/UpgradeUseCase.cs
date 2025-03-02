using System;
using FPSShooter.Modules.CurrencyStorage;
using UnityEngine;

namespace FPSShooter.Modules.Meta.Upgrades
{
    [Serializable]
    public sealed class UpgradeUseCase
    {
        // [ShowInInspector] private readonly ICurrencyStorage _moneyStorage;
        // [ShowInInspector] private readonly Dictionary<string, Upgrade> _upgrades;
        //
        // public UpgradeManager(UpgradeFactory factory, ICurrencyStorage moneyStorage)
        // {
        //     _upgrades = new Dictionary<string, Upgrade>();
        //     _moneyStorage = moneyStorage;
        //     
        //     var upgrades = factory.CreateUpgrades();
        //     foreach (var upgrade in upgrades)
        //     {
        //         _upgrades.Add(upgrade.Id, upgrade);
        //     }
        // }
        
        public static void LevelUp(Upgrade upgrade, ICurrencyStorage currencyStorage)
        {
            if (!upgrade.CanLevelUp)
            {
                Debug.LogWarning($"Cannot level up {upgrade.DisplayName}");
                return;
            }

            if (upgrade.CurrentPrice > currencyStorage.Amount)
            {
                Debug.LogWarning($"Not enough money to level up {upgrade.DisplayName}");
                return;
            }
            
            currencyStorage.Get((int)upgrade.CurrentPrice);
            
            upgrade.LevelUp();
        }

        // public Upgrade[] GetUpgrades()
        // {
        //     var result = new Upgrade[_upgrades.Count];
        //     for(int i = 0; i < _upgrades.Count; i++)
        //     {
        //         result[i] = _upgrades.ElementAt(i).Value;
        //     }
        //     return result;
        // }
    }
}