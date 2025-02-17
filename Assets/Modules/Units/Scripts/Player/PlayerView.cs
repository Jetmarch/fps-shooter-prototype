using FPSShooter.Modules.Core.GameLoop;
using FPSShooter.Modules.FPSCamera;
using FPSShooter.Modules.Gameplay.Weapons;
using FPSShooter.Modules.Movement;
using UnityEngine;
using VContainer;

namespace FPSShooter.Modules.Units
{
    public sealed class PlayerView : MonoBehaviour, IUpdateListener, ILateUpdateListener
    {
        [SerializeField] private Transform _cameraTarget;

        private IFPSCameraController _fpsCamera;
        private IMovementController _movementController;
        private WeaponSwayEffect _weaponSwayEffect;
        private PlayerHands _hands;
        private HandsWobbleAnimation _wobbleAnimation;
        private HandsFollowCameraLook _handsFollowCameraLook;

        private CharacterInput _lastCharacterInput;

        [Inject]
        private void Construct(IMovementController movementController, IFPSCameraController fpsCamera,
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
            _hands.ShootCurrentWeapon();
        }

        public void ShootStartAutomatic()
        {
            _hands.StartShootAutomaticCurrentWeapon();
        }

        public void ShootEndAutomatic()
        {
            _hands.EndShotAutomaticCurrentWeapon();
        }

        public void Reload()
        {
            _hands.ReloadCurrentWeapon();
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
            _fpsCamera.Update(deltaTime);
            _handsFollowCameraLook.Update(deltaTime);
            _wobbleAnimation.Update(deltaTime);
            
            _weaponSwayEffect.Update(deltaTime);
        }
    }
}
