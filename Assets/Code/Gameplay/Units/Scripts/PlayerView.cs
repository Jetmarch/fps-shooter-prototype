using System;
using System.Collections.Generic;
using FPSShooter.Core.Managers;
using FPSShooter.Gameplay.FPSCamera;
using FPSShooter.Gameplay.Weapons;
using KinematicCharacterController;
using UnityEngine;
using VContainer;

namespace FPSShooter.Gameplay.Units
{
    public sealed class PlayerView : MonoBehaviour, IUpdateListener, ILateUpdateListener
    {
        [SerializeField, ReadOnly] private MovementController _movementController;
        [SerializeField] private FPSCameraController _fpsCamera;
        [SerializeField] private Transform _cameraTarget;
        [SerializeField] private float _handsFollowSpeed = 25f;

        [SerializeField] private Transform _weaponParent;
        [SerializeField] private List<WeaponView> _weapons;
        [SerializeField] private WeaponView _currentWeapon;
        [SerializeField] private int _currentWeaponIndex;

        private CharacterInput _lastCharacterInput;

        private void Start()
        {
            _initialHandsPosition = _weaponParent.localPosition;
            _initialHandsRotation = _weaponParent.localRotation;
        }

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
            _lastCharacterInput = new CharacterInput
            {
                Move = movementVector,
                Rotation = _fpsCamera.Rotation,
            };
            _movementController.UpdateInput(_lastCharacterInput);
        }

        public void Look(Vector2 lookVector)
        {
            _fpsCamera.Look(lookVector);
        }

        public void RequestJump()
        {
            _movementController.RequestJump();
        }

        public void AddWeapon(WeaponView weapon)
        {
            if (_weapons.Contains(weapon)) return;
            _weapons.Add(weapon);
            SetCurrentWeapon(weapon);
        }

        public void SetNextWeapon()
        {
            _currentWeaponIndex++;
            if (_currentWeaponIndex > _weapons.Count - 1)
            {
                _currentWeaponIndex = 0;
            }
            
            SetCurrentWeapon(_currentWeaponIndex);
        }

        public void SetPreviousWeapon()
        {
            _currentWeaponIndex--;
            if (_currentWeaponIndex < 0)
            {
                _currentWeaponIndex = _weapons.Count - 1;
            }

            SetCurrentWeapon(_currentWeaponIndex);
        }

        private void SetCurrentWeapon(int weaponIndex)
        {
            if (weaponIndex >= _weapons.Count || weaponIndex < 0) return;

            PrepareNewWeapon(_weapons[weaponIndex]);
        }

        private void SetCurrentWeapon(WeaponView weapon)
        {
            if (!_weapons.Contains(weapon)) return;
            
            PrepareNewWeapon(weapon);
        }

        private void PrepareNewWeapon(WeaponView weapon)
        {
            if (_currentWeapon)
            {
                _currentWeapon.gameObject.SetActive(false);
            }
            _currentWeapon = weapon;
            _currentWeapon.gameObject.SetActive(true);
            _currentWeapon.transform.position = _weaponParent.position;
            _currentWeapon.transform.rotation = _weaponParent.rotation;
            weapon.transform.SetParent(_weaponParent);
        }

        public void OnUpdate(float deltaTime)
        {
             _movementController.UpdateBody(deltaTime);
        }

        public void OnLateUpdate(float deltaTime)
        {
            _fpsCamera.OnLateUpdate(deltaTime);
            HandsFollowCameraLook(deltaTime);
            WobbleHands(deltaTime);
        }

        private void HandsFollowCameraLook(float deltaTime)
        {
            _cameraTarget.rotation = Quaternion.Slerp(_cameraTarget.rotation, _fpsCamera.Rotation, deltaTime * _handsFollowSpeed);
        }

        [SerializeField] private float _wobbleTime;
        [SerializeField] private float _wobbleSpeed = 1;
        [SerializeField] private float _positionWobbleStrength = 0.1f;
        [SerializeField] private float _rotationWobbleStrength = 0.5f;
        [SerializeField] private float _wobbleSmoothnes = 5f;
        private Vector3 _initialHandsPosition;
        private Quaternion _initialHandsRotation;
        private void WobbleHands(float deltaTime)
        {
            bool isMoving = _lastCharacterInput.Move.x != 0 || _lastCharacterInput.Move.y != 0;

            if (isMoving)
            {
                _wobbleTime += deltaTime * _wobbleSpeed;

                var currentPositionWobbleStrength = _positionWobbleStrength * _lastCharacterInput.Move.magnitude;
                var currentRotationWobbleStrength = _rotationWobbleStrength * _lastCharacterInput.Move.magnitude;

                var positionWobble = new Vector3(
                    Mathf.Sin(_wobbleTime * 2f) * currentPositionWobbleStrength,
                    // Mathf.Sin(_wobbleTime) * currentPositionWobbleStrength,
                    0f);

                var rotationWobble = new Vector3(
                    Mathf.Sin(_wobbleTime) * currentRotationWobbleStrength,
                    Mathf.Sin(_wobbleTime * 0.5f) * currentRotationWobbleStrength,
                    Mathf.Cos(_wobbleTime) * currentRotationWobbleStrength);

                _weaponParent.localPosition = Vector3.Lerp(_weaponParent.localPosition, _initialHandsPosition + positionWobble, _wobbleSmoothnes * deltaTime);
                // _cameraTarget.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(rotationWobble) * _initialHandsRotation, _wobbleSmoothnes * deltaTime);
            }
            else
            {
                _weaponParent.localPosition = Vector3.Lerp(_weaponParent.localPosition, _initialHandsPosition, _wobbleSmoothnes * deltaTime);
                _wobbleTime = 0f;
            }
        }
    }
}
