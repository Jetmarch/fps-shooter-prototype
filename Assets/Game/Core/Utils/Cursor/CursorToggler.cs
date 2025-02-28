using System;
using FPSShooter.Core.Systems;
using UnityEngine;
using VContainer.Unity;

// ReSharper disable ClassNeverInstantiated.Global

namespace FPSShooter.Core.Utils
{
    public sealed class CursorToggler
    {
        public void ShowCursor()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        public void HideCursor()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
