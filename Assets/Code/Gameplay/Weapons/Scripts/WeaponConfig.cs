using UnityEngine;
using VContainer;

namespace FPSShooter.Gameplay.Weapons
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "FPS Shooter/Weapons/WeaponConfig")]
    public sealed class WeaponConfig : ScriptableObject
    {
        [SerializeField] private Weapon _weapon;

        public Weapon GetClone(IObjectResolver objectResolver)
        {
            var weaponClone = _weapon.Clone();
            objectResolver.Inject(weaponClone);
            return weaponClone;
        }
    }
}