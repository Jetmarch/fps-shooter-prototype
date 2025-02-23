using FPSShooter.Modules.Gameplay.Impact;
using FPSShooter.Modules.Gameplay.Weapons;
using Modules.Units.Scripts.Presenters;
using UnityEngine;
using VContainer;

namespace FPSShooter.Modules.Units
{
    public sealed class UnitView : MonoBehaviour, IAffectableObject
    {
        private IUnitPresenter _presenter;

        [Inject]
        private void Construct(IUnitPresenter presenter)
        {
            _presenter = presenter;
        }

        public void Shoot()
        {
            _presenter.Shoot();
        }

        public void ShootStartAutomatic()
        {
            _presenter.ShootStartAutomatic();
        }

        public void ShootEndAutomatic()
        {
            _presenter.ShootEndAutomatic();
        }

        public void Reload()
        {
            _presenter.Reload();
        }

        public void Move(Vector2 movementVector)
        {
            _presenter.Move(movementVector);
        }

        public void Look(Vector2 lookVector)
        {
            _presenter.Look(lookVector);
        }

        public void RequestJump()
        {
            _presenter.RequestJump();
        }

        public void AddWeapon(IWeapon weapon)
        {
            _presenter.AddWeapon(weapon);
        }

        public void SetNextWeapon()
        {
            _presenter.SetNextWeapon();
        }

        public void SetPreviousWeapon()
        {
            _presenter.SetPreviousWeapon();
        }

        public void Affect(ImpactData impactData)
        {
            _presenter.Affect(impactData);
        }
        public void TearApartDeath()
        {
            _presenter.TearApartDeath();
        }

        public void SimpleDeath()
        {
            _presenter.Die();
        }
    }
}
