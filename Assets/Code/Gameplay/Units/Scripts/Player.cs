using FPSShooter.Core.Managers;
using FPSShooter.Gameplay.FPSCamera;
using FPSShooter.Gameplay.Weapons;
using KinematicCharacterController;
using UnityEngine;
using VContainer;

namespace FPSShooter.Gameplay.Units
{
    public sealed class Player : MonoBehaviour, IUpdateListener, ILateUpdateListener
    {
        [SerializeField, ReadOnly] private MovementController _movementController;
        [SerializeField] private FPSCameraController _fpsCamera;

        [SerializeField] private WeaponView _currentWeapon;
        [Inject]
        private void Construct(MovementController movementController, FPSCameraController fpsCamera)
        {
            _movementController = movementController;
            _fpsCamera = fpsCamera;
        }

        public void RequestFire()
        {
            _currentWeapon.Shoot();
        }

        public void Move(Vector2 movementVector)
        {
            var characterInput = new CharacterInput
            {
                Move = movementVector,
                Rotation = _fpsCamera.Rotation,
            };
            _movementController.UpdateInput(characterInput);
        }

        public void Look(Vector2 lookVector)
        {
            _fpsCamera.Look(lookVector);
        }

        public void RequestJump()
        {
            _movementController.RequestJump();
        }

        public void OnUpdate(float deltaTime)
        {
             _movementController.UpdateBody(deltaTime);
        }

        public void OnLateUpdate(float deltaTime)
        {
            _fpsCamera.OnLateUpdate(deltaTime);
        }
    }
}
