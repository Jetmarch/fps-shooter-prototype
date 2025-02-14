using FPSShooter.Core.Managers;
using FPSShooter.Gameplay.FPSCamera;
using FPSShooter.Gameplay.Weapons;
using KinematicCharacterController;
using UnityEngine;
using VContainer;

namespace FPSShooter.Gameplay.Units
{
    public sealed class PlayerView : MonoBehaviour, IUpdateListener, ILateUpdateListener, IFixedUpdateListener
    {
        [SerializeField, ReadOnly] private MovementController _movementController;
        [SerializeField] private FPSCameraController _fpsCamera;
        [SerializeField] private Transform _cameraTarget;

        private WeaponSwayEffect _weaponSwayEffect;
        
        private PlayerHands _hands;
        private HandsWobbleAnimation _wobbleAnimation;
        private HandsFollowCameraLook _handsFollowCameraLook;

        private CharacterInput _lastCharacterInput;

        [Inject]
        private void Construct(MovementController movementController, FPSCameraController fpsCamera,
            HandsFollowCameraLook handsFollowCameraLook,
            HandsWobbleAnimation wobbleAnimation,
            PlayerHands hands,
            WeaponSwayEffect weaponSwayEffect)
        {
            _movementController = movementController;
            _fpsCamera = fpsCamera;
            _handsFollowCameraLook = handsFollowCameraLook;
            _wobbleAnimation = wobbleAnimation;
            _hands = hands;
            _weaponSwayEffect = weaponSwayEffect;
        }

        public void Shoot()
        {
            _hands.Shoot();
        }

        public void Move(Vector2 movementVector)
        {
            _lastCharacterInput = new CharacterInput
            {
                Move = movementVector,
                Rotation = _fpsCamera.Rotation,
            };
            _movementController.UpdateInput(_lastCharacterInput);
            _wobbleAnimation.UpdateInput(movementVector);
        }

        public void Look(Vector2 lookVector)
        {
            _fpsCamera.Look(lookVector);
            _weaponSwayEffect.UpdateInput(lookVector);
        }

        public void RequestJump()
        {
            _movementController.RequestJump();
        }

        public void AddWeapon(IWeapon weapon)
        {
            _hands.AddWeapon(weapon);
        }

        public void SetNextWeapon()
        {
            _hands.NextWeapon();
        }

        public void SetPreviousWeapon()
        {
            _hands.PreviousWeapon();
        }

        public void OnUpdate(float deltaTime)
        {
            _movementController.UpdateBody(deltaTime);
            
        }

        public void OnLateUpdate(float deltaTime)
        {
            _fpsCamera.UpdatePosition(deltaTime);
            _fpsCamera.UpdateRotation(deltaTime);
            _handsFollowCameraLook.Update(deltaTime);
            _wobbleAnimation.Update(deltaTime);
            
            _weaponSwayEffect.Update(deltaTime);
        }

        public void OnFixedUpdate(float deltaTime)
        {
            
        }
    }
}
