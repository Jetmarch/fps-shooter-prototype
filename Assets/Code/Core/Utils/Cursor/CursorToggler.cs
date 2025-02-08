using UnityEngine;
// ReSharper disable ClassNeverInstantiated.Global

namespace FPSShooter.Core.Managers
{
    public sealed class CursorToggler : IUpdateListener
    {
        public void OnUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.visible = !Cursor.visible;
                Cursor.lockState = Cursor.visible ? CursorLockMode.None : CursorLockMode.Locked;
            }
        }
    }
}
