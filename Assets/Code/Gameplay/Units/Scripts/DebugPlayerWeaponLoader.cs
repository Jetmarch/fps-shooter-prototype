using FPSShooter.Gameplay.Weapons;
using VContainer.Unity;

namespace FPSShooter.Gameplay.Units
{
    public sealed class DebugPlayerWeaponLoader : IInitializable
    {
        private readonly PlayerView _playerView;
        private readonly WeaponManager _weaponManager;

        public DebugPlayerWeaponLoader(PlayerView playerView, WeaponManager weaponManager)
        {
            _playerView = playerView;
            _weaponManager = weaponManager;
        }
        
        public void Initialize()
        {
            var weapons = _weaponManager.GetWeapons();
            foreach (var weapon in weapons)
            {
                _playerView.AddWeapon(weapon);
            }
        }
    }
}