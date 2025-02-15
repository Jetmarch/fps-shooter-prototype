using System;
using FPSShooter.Core.Systems;
using FPSShooter.Gameplay;
using FPSShooter.Gameplay.Units;
using VContainer.Unity;

namespace FPSShooter.Observers
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class PlayerInputObserver : IInitializable, IDisposable
    {
        private readonly InputSystem _inputSystem;
        private readonly PlayerView _playerView;
        public PlayerInputObserver(InputSystem inputSystem, PlayerView playerView)
        {
            _inputSystem = inputSystem;
            _playerView = playerView;
        }

        public void Initialize()
        {
            _inputSystem.OnFire += _playerView.Shoot;
            _inputSystem.OnStartAutomaticFire += _playerView.ShootStartAutomatic;
            _inputSystem.OnEndAutomaticFire += _playerView.ShootEndAutomatic;
            _inputSystem.OnReload += _playerView.Reload;
            _inputSystem.OnJump += _playerView.RequestJump;
            _inputSystem.OnMove += _playerView.Move;
            _inputSystem.OnLook += _playerView.Look;
            _inputSystem.OnMouseWheelUp += _playerView.SetNextWeapon;
            _inputSystem.OnMouseWheelDown += _playerView.SetPreviousWeapon;
        }

        public void Dispose()
        {
            _inputSystem.OnMouseWheelDown -= _playerView.SetPreviousWeapon;
            _inputSystem.OnMouseWheelUp -= _playerView.SetNextWeapon;
            _inputSystem.OnLook -= _playerView.Look;
            _inputSystem.OnMove -= _playerView.Move;
            _inputSystem.OnJump -= _playerView.RequestJump;
            _inputSystem.OnReload -= _playerView.Reload;
            _inputSystem.OnEndAutomaticFire -= _playerView.ShootEndAutomatic;
            _inputSystem.OnStartAutomaticFire -= _playerView.ShootStartAutomatic;
            _inputSystem.OnFire -= _playerView.Shoot;
        }
    }
}
