using FPSShooter.Core.Managers;
using FPSShooter.Gameplay.FPSCamera;
using KinematicCharacterController;
using UnityEngine;
using VContainer;

namespace FPSShooter.Gameplay
{
    public sealed class Player : MonoBehaviour, IUpdateListener
    {
        [SerializeField, ReadOnly] private MovementController _movementController;
        [SerializeField] private FPSCameraController _fpsCamera;
        private Vector2 _movementDirection;
        
        //private WeaponHolder _weaponHolder;

        [Inject]
        private void Construct(MovementController movementController, FPSCameraController fpsCamera)
        {
            _movementController = movementController;
            _fpsCamera = fpsCamera;
        }
        
        public void RequestFire()
        {
            Debug.Log("RequestFire");
            //_weaponHolder.RequestFire();a 
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
    }
}
