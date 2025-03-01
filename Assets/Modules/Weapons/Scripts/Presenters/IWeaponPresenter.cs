using FPSShooter.Modules.Meta.Upgrades;

namespace FPSShooter.Modules.Gameplay.Weapons
{
    public interface IWeaponPresenter
    {
        public void Shoot();
        public void StartShootAutomatic();
        public void EndShootAutomatic();
        public void Reload();
        public void PullOut();
        public void PutAway();
        void StartUpgrading();
        void StopUpgrading();
        Upgrade[] GetAvailableUpgrades();
    }
}