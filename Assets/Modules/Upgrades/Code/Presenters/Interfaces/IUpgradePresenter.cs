namespace FPSShooter.Modules.Meta.Upgrades.Presenters
{
    public interface IUpgradePresenter
    {
        string Name { get; }
        string Value { get; }
        string Level { get; }
        IUpgradeButtonPresenter GetUpgradeButtonPresenter();
    }
}