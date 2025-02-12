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

        [SerializeField] private Transform _weaponParent;
        [SerializeField] private List<WeaponView> _weapons;
        [SerializeField] private WeaponView _currentWeapon;
        [SerializeField] private int _currentWeaponIndex;
        
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
            _cameraTarget.rotation = _fpsCamera.Rotation;
        }
    }
}
