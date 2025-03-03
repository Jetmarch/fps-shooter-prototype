using FPSShooter.Game.Gameplay.Units.UnitLogic;
using FPSShooter.Modules.Gameplay.Weapons;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Units
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class DebugPlayerWeaponLoader : IInitializable
    {
        private readonly WeaponArsenalMechanic _weaponArsenalMechanic;
        private readonly WeaponManager _weaponManager;

        public DebugPlayerWeaponLoader(WeaponArsenalMechanic weaponArsenalMechanic, WeaponManager weaponManager)
        {
            _weaponArsenalMechanic = weaponArsenalMechanic;
            _weaponManager = weaponManager;
        }
        
        public void Initialize()
        {
            // var weapons = _weaponManager.GetWeapons();
            // foreach (var weapon in weapons.Values)
            // {
            //     _weaponArsenalMechanic.AddWeapon(weapon);
            // }
        }
    }
}