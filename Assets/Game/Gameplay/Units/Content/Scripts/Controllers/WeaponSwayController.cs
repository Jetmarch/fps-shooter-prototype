using System;
using FPSShooter.Core.Systems;
using FPSShooter.Modules.Units;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Units
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class WeaponSwayController : IInitializable, IDisposable
    {
        private readonly WeaponSwayEffect _weaponSwayEffect;
        private readonly IInputSystem _inputSystem;

        public WeaponSwayController(WeaponSwayEffect weaponSwayEffect, IInputSystem inputSystem)
        {
            _weaponSwayEffect = weaponSwayEffect;
            _inputSystem = inputSystem;
        }

        public void Initialize()
        {
            _inputSystem.OnLook += _weaponSwayEffect.OnLook;
        }

        public void Dispose()
        {
            _inputSystem.OnLook -= _weaponSwayEffect.OnLook;
        }
    }
}