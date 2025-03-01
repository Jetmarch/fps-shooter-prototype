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
        private readonly FirstPersonCharacterMechanic _fpsMechanic;
        public PlayerMoveInputObserver(IInputSystem inputSystem, FirstPersonCharacterMechanic fpsMechanic)
        {
            _inputSystem = inputSystem;
            _fpsMechanic = fpsMechanic;
        }

        public void Initialize()
        {
            _inputSystem.OnJump += _fpsMechanic.RequestJump;
            _inputSystem.OnMove += _fpsMechanic.Move;
            _inputSystem.OnLook += _fpsMechanic.Look;
        }

        public void Dispose()
        {
            _inputSystem.OnLook -= _fpsMechanic.Look;
            _inputSystem.OnMove -= _fpsMechanic.Move;
            _inputSystem.OnJump -= _fpsMechanic.RequestJump;
        }
    }
}
