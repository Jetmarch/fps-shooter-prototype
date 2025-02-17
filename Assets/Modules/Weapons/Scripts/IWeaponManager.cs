using System.Collections.Generic;

namespace FPSShooter.Modules.Gameplay.Weapons
{
    public interface IWeaponManager
    {
        List<WeaponView> GetWeapons();
    }
}