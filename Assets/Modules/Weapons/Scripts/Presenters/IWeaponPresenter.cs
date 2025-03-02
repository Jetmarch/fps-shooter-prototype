using FPSShooter.Modules.Meta.Upgrades;

namespace FPSShooter.Modules.Gameplay.Weapons
{
    public interface IWeaponPresenter
    {
        string GetWeaponName();
        void Shoot();
        void StartShootAutomatic();
        void EndShootAutomatic();
        void Reload();
        void PullOut();
        void PutAway();
        void StartUpgrading();
        void StopUpgrading();
        Upgrade[] GetAvailableUpgrades();
    }
}