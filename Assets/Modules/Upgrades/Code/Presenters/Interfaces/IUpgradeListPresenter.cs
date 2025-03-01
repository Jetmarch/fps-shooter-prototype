using System.Collections.Generic;

namespace FPSShooter.Modules.Meta.Upgrades.Presenters
{
    public interface IUpgradeListPresenter
    {
        List<IUpgradePresenter> GetUpgradePresenters();
    }
}