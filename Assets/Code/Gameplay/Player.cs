using FPSShooter.Core.Managers;
using KinematicCharacterController;
using UnityEngine;
using VContainer;

namespace FPSShooter.Gameplay
{
    public sealed class Player : MonoBehaviour, IUpdateListener
    {
        [SerializeField, ReadOnly] private MovementController _movementController;

        [Header("Camera Settings")]
        [SerializeField] private Transform _playerCamera;
        [SerializeField] private float _cameraSensitivity = 0.1f;
        [SerializeField, ReadOnly] private Vector3 _cameraEulerAngles;

        private Vector2 _movementDirection;
        private Quaternion _lookDirection;
        
        //private WeaponHolder _weaponHolder;

        [Inject]
        private void Construct(MovementController movementController)
        {
            _movementController = movementController;
        }
        
        public void RequestFire()
        {
            Debug.Log("RequestFire");
            //_weaponHolder.RequestFire();
        }

        public void Move(Vector2 movementVector)
        {
            var characterInput = new CharacterInput
            {
                Move = movementVector,
                Rotation = _lookDirection,
            };
            _movementController.UpdateInput(characterInput);
        }

        public void Look(Vector2 lookVector)
        {
            _lookDirection = Quaternion.Euler(lookVector);
            
            _cameraEulerAngles += new Vector3(lookVector.x, lookVector.y) * _cameraSensitivity;
            _playerCamera.eulerAngles = _lookDirection.eulerAngles;
        }

        public void RequestJump()
        {
            Debug.Log("RequestJump");
            _movementController.RequestJump();
        }

        public void OnUpdate(float deltaTime)
        {
            _movementController.UpdateBody(deltaTime);
        }
    }
}
