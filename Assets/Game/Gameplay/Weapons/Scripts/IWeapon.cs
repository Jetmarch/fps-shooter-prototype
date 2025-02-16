using UnityEngine;

namespace FPSShooter.Gameplay.Weapons
{
    public interface IWeapon
    {
        void RequestShoot();
        void RequestStartAutomaticShoot();
        void RequestEndAutomaticShoot();
        void RequestReload();
        Vector3 Position { get; set; }
        Quaternion Rotation { get; set; }
        void SetActive(bool isActive);
        void SetParent(Transform parent);
    }
}