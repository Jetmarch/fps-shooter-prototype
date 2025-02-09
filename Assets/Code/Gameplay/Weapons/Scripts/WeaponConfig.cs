using UnityEngine;

namespace FPSShooter.Gameplay.Weapons
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "FPS Shooter/Weapons/WeaponConfig")]
    public sealed class WeaponConfig : ScriptableObject
    {
        [SerializeField] private Weapon _weapon;

        public Weapon GetClone()
        {
            return _weapon.Clone();
        }
    }
}