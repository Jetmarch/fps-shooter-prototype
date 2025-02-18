using FPSShooter.Modules.Core.GameLoop;
using FPSShooter.Modules.FPSCamera;
using FPSShooter.Modules.Gameplay.Weapons;
using FPSShooter.Modules.Movement;
using FPSShooter.Modules.Units;
using Modules.Units.Scripts.Presenters;
using UnityEngine;

namespace FPSShooter.Game.Gameplay.Units.Player
{
    public sealed class PlayerPresenter : IUnitPresenter, IUpdateListener, ILateUpdateListener
    {
        private readonly UnitView _view;
        private readonly IFPSCameraController _fpsCamera;
        private readonly IMovementController _movementController;
        private readonly WeaponHolder _weaponHolder;


        public PlayerPresenter(UnitView view, IFPSCameraController fpsCamera, IMovementController movementController, WeaponHolder weaponHolder)
        {
            _view = view;
            _fpsCamera = fpsCamera;
            _movementController = movementController;
            _weaponHolder = weaponHolder;
        }

        public void Shoot()
        {
            _weaponHolder.ShootCurrentWeapon();
        }

        public void ShootStartAutomatic()
        {
            _weaponHolder.StartShootAutomaticCurrentWeapon();
        }

        public void ShootEndAutomatic()
        {
            _weaponHolder.EndShotAutomaticCurrentWeapon();
        }

        public void Reload()
        {
            _weaponHolder.ReloadCurrentWeapon();
        }

        public void Move(Vector2 movementVector)
        {
            var lastCharacterInput = new CharacterInput
            {
                Move = movementVector,
                Rotation = _fpsCamera.Rotation,
            };
            _movementController.UpdateInput(lastCharacterInput);
        }

        public void Look(Vector2 lookVector)
        {
            _fpsCamera.Look(lookVector);
        }

        public void RequestJump()
        {
            _movementController.RequestJump();
        }

        public void AddWeapon(IWeapon weapon)
        {
            _weaponHolder.AddWeapon(weapon);
        }

        public void SetNextWeapon()
        {
            _weaponHolder.NextWeapon();
        }

        public void SetPreviousWeapon()
        {
            _weaponHolder.PreviousWeapon();
        }

        public void OnUpdate(float deltaTime)
        {
            _movementController.UpdateBody(deltaTime);
        }

        public void OnLateUpdate(float deltaTime)
        {
            _fpsCamera.Update(deltaTime);
        }
    }
}