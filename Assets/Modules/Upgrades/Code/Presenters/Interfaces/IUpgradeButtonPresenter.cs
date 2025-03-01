using System;

namespace FPSShooter.Modules.Meta.Upgrades.Presenters
{
    public interface IUpgradeButtonPresenter
    {
        string Price { get; }
        bool CanLevelUp { get; }
        bool CanBuy { get; }
        
        void LevelUp();
        void Dispose();
        event Action OnMoneyChanged;
    }
}