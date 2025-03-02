using System.Collections.Generic;

namespace FPSShooter.Modules.Gameplay.Weapons
{
    public interface IWeaponManager
    {
        Dictionary<string, WeaponView> GetWeapons();
    }
}