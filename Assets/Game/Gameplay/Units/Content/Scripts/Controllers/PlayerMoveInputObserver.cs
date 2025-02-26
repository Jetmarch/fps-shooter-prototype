using System;
using FPSShooter.Core.Systems;
using FPSShooter.Game.Gameplay.Units.UnitLogic;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Units
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class PlayerMoveInputObserver : IInitializable, IDisposable
    {
        private readonly IInputSystem _inputSystem;
        private readonly FirstPersonCharacterMechanics _fpsMechanics;
        public PlayerMoveInputObserver(IInputSystem inputSystem, FirstPersonCharacterMechanics fpsMechanics)
        {
            _inputSystem = inputSystem;
            _fpsMechanics = fpsMechanics;
        }

        public void Initialize()
        {
            _inputSystem.OnJump += _fpsMechanics.RequestJump;
            _inputSystem.OnMove += _fpsMechanics.Move;
            _inputSystem.OnLook += _fpsMechanics.Look;
        }

        public void Dispose()
        {
            _inputSystem.OnLook -= _fpsMechanics.Look;
            _inputSystem.OnMove -= _fpsMechanics.Move;
            _inputSystem.OnJump -= _fpsMechanics.RequestJump;
        }
    }
    
    public sealed class PlayerWeaponInputObserver : IInitializable, IDisposable
    {
        private readonly IInputSystem _inputSystem;
        private readonly WeaponArsenalMechanic _weaponArsenalMechanic;
        public PlayerWeaponInputObserver(IInputSystem inputSystem, WeaponArsenalMechanic weaponArsenalMechanic)
        {
            _inputSystem = inputSystem;
            _weaponArsenalMechanic = weaponArsenalMechanic;
        }

        public void Initialize()
        {
            _inputSystem.OnFire += _weaponArsenalMechanic.Shoot;
            _inputSystem.OnStartAutomaticFire += _weaponArsenalMechanic.ShootStartAutomatic;
            _inputSystem.OnEndAutomaticFire += _weaponArsenalMechanic.ShootEndAutomatic;
            _inputSystem.OnReload += _weaponArsenalMechanic.Reload;
            _inputSystem.OnMouseWheelUp += _weaponArsenalMechanic.SetNextWeapon;
            _inputSystem.OnMouseWheelDown += _weaponArsenalMechanic.SetPreviousWeapon;
        }

        public void Dispose()
        {
            _inputSystem.OnMouseWheelDown -= _weaponArsenalMechanic.SetPreviousWeapon;
            _inputSystem.OnMouseWheelUp -= _weaponArsenalMechanic.SetNextWeapon;
            _inputSystem.OnReload -= _weaponArsenalMechanic.Reload;
            _inputSystem.OnEndAutomaticFire -= _weaponArsenalMechanic.ShootEndAutomatic;
            _inputSystem.OnStartAutomaticFire -= _weaponArsenalMechanic.ShootStartAutomatic;
            _inputSystem.OnFire -= _weaponArsenalMechanic.Shoot;
        }
    }
}
