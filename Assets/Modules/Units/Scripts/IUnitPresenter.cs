using FPSShooter.Modules.Gameplay.Impact;
using FPSShooter.Modules.Gameplay.Weapons;
using UnityEngine;

namespace Modules.Units.Scripts.Presenters
{
    //TODO: move shoot logic to (?)
    public interface IUnitPresenter
    {
        void Shoot();
        void ShootStartAutomatic();
        void ShootEndAutomatic();
        void Reload();
        void Move(Vector2 movementVector);
        void Look(Vector2 lookVector);
        void RequestJump();
        void AddWeapon(IWeapon weapon);
        void SetNextWeapon();
        void SetPreviousWeapon();
        void Affect(ImpactData impactData);
        void TearApartDeath();
        void Die();
        ObjectState GetObjectStateData();
        void Update(float deltaTime);
    }
}