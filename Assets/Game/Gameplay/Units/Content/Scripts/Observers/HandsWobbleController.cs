using System;
using FPSShooter.Core.Systems;
using VContainer.Unity;

namespace FPSShooter.Modules.Units
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class HandsWobbleController : IInitializable, IDisposable
    {
        private readonly HandsWobbleAnimation _handsWobbleAnimation;
        private readonly IInputSystem _inputSystem;

        public HandsWobbleController(HandsWobbleAnimation handsWobbleAnimation, IInputSystem inputSystem)
        {
            _handsWobbleAnimation = handsWobbleAnimation;
            _inputSystem = inputSystem;
        }

        public void Initialize()
        {
            _inputSystem.OnLook += _handsWobbleAnimation.OnLook;
        }

        public void Dispose()
        {
            _inputSystem.OnLook -= _handsWobbleAnimation.OnLook;
        }
    }
}