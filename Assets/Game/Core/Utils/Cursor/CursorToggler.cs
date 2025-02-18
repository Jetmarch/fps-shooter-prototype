using System;
using FPSShooter.Core.Systems;
using UnityEngine;
using VContainer.Unity;

// ReSharper disable ClassNeverInstantiated.Global

namespace FPSShooter.Core.Utils
{
    public sealed class CursorToggler : IInitializable, IDisposable
    {
        private readonly IInputSystem _inputSystem;

        public CursorToggler(IInputSystem inputSystem)
        {
            _inputSystem = inputSystem;
        }

        public void Initialize()
        {
            _inputSystem.OnMenu += ToggleCursor;
        }

        public void Dispose()
        {
            _inputSystem.OnMenu -= ToggleCursor;
        }

        private void ToggleCursor()
        {
            Debug.Log("Cursor toggled");
            Cursor.visible = !Cursor.visible;
            Cursor.lockState = Cursor.visible ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }
}
