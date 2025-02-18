using FPSShooter.Modules.Gameplay.Weapons;
using FPSShooter.Modules.Units;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Units
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class DebugPlayerWeaponLoader : IInitializable
    {
        private readonly UnitView _unitView;
        private readonly WeaponManager _weaponManager;

        public DebugPlayerWeaponLoader(UnitView unitView, WeaponManager weaponManager)
        {
            _unitView = unitView;
            _weaponManager = weaponManager;
        }
        
        public void Initialize()
        {
            var weapons = _weaponManager.GetWeapons();
            foreach (var weapon in weapons)
            {
                _unitView.AddWeapon(weapon);
            }
        }
    }
}