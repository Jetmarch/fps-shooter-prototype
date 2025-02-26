using FPSShooter.Modules.Gameplay.Weapons;
using FPSShooter.Modules.Units;

namespace FPSShooter.Game.Gameplay.Units.UnitLogic
{
    public sealed class WeaponArsenalMechanic : IUnitMechanics
    {
        private readonly WeaponContainer _weaponContainer;

        public WeaponArsenalMechanic(WeaponContainer weaponContainer)
        {
            _weaponContainer = weaponContainer;
        }
        
        public void Shoot()
        {
            _weaponContainer.ShootCurrentWeapon();
        }

        public void ShootStartAutomatic()
        {
            _weaponContainer.StartShootAutomaticCurrentWeapon();
        }

        public void ShootEndAutomatic()
        {
            _weaponContainer.EndShotAutomaticCurrentWeapon();
        }

        public void Reload()
        {
            _weaponContainer.ReloadCurrentWeapon();
        }

        public void AddWeapon(IWeapon weapon)
        {
            _weaponContainer.AddWeapon(weapon);
        }

        public void SetNextWeapon()
        {
            _weaponContainer.NextWeapon();
        }

        public void SetPreviousWeapon()
        {
            _weaponContainer.PreviousWeapon();
        }
    }
}