using System;
using FPSShooter.Core.Systems;
using FPSShooter.Gameplay;
using VContainer.Unity;

namespace FPSShooter.Observers
{
    public sealed class PlayerInputObserver : IInitializable, IDisposable
    {
        private readonly InputSystem _inputSystem;
        private readonly Player _player;

        public PlayerInputObserver(InputSystem inputSystem, Player player)
        {
            _inputSystem = inputSystem;
            _player = player;
        }

        public void Initialize()
        {
            _inputSystem.OnFire += _player.RequestFire;
            _inputSystem.OnJump += _player.RequestJump;
            _inputSystem.OnMove += _player.Move;
            _inputSystem.OnLook += _player.Look;
        }

        public void Dispose()
        {
            _inputSystem.OnFire -= _player.RequestFire;
            _inputSystem.OnJump -= _player.RequestJump;
            _inputSystem.OnMove -= _player.Move;
            _inputSystem.OnLook -= _player.Look;
        }
    }
}
