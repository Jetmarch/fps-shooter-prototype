using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace FPSShooter.Modules.Gameplay.Weapons
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "FPS Shooter/Weapons/WeaponConfig")]
    public sealed class WeaponConfig : SerializedScriptableObject
    {
        [OdinSerialize] private Weapon _weapon;

        public Weapon CreateWeapon()
        {
            return _weapon.Clone();
        }
    }
}