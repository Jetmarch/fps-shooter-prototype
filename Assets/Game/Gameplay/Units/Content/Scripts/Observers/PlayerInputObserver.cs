using System;
using FPSShooter.Core.Systems;
using VContainer.Unity;

namespace FPSShooter.Modules.Units
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class PlayerInputObserver : IInitializable, IDisposable
    {
        private readonly IInputSystem _inputSystem;
        private readonly UnitView _unitView;
        public PlayerInputObserver(IInputSystem inputSystem, UnitView unitView)
        {
            _inputSystem = inputSystem;
            _unitView = unitView;
        }

        public void Initialize()
        {
            _inputSystem.OnFire += _unitView.Shoot;
            _inputSystem.OnStartAutomaticFire += _unitView.ShootStartAutomatic;
            _inputSystem.OnEndAutomaticFire += _unitView.ShootEndAutomatic;
            _inputSystem.OnReload += _unitView.Reload;
            _inputSystem.OnJump += _unitView.RequestJump;
            _inputSystem.OnMove += _unitView.Move;
            _inputSystem.OnLook += _unitView.Look;
            _inputSystem.OnMouseWheelUp += _unitView.SetNextWeapon;
            _inputSystem.OnMouseWheelDown += _unitView.SetPreviousWeapon;
        }

        public void Dispose()
        {
            _inputSystem.OnMouseWheelDown -= _unitView.SetPreviousWeapon;
            _inputSystem.OnMouseWheelUp -= _unitView.SetNextWeapon;
            _inputSystem.OnLook -= _unitView.Look;
            _inputSystem.OnMove -= _unitView.Move;
            _inputSystem.OnJump -= _unitView.RequestJump;
            _inputSystem.OnReload -= _unitView.Reload;
            _inputSystem.OnEndAutomaticFire -= _unitView.ShootEndAutomatic;
            _inputSystem.OnStartAutomaticFire -= _unitView.ShootStartAutomatic;
            _inputSystem.OnFire -= _unitView.Shoot;
        }
    }
}
