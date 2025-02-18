using System;
using FPSShooter.Modules.Core.GameLoop;
using UnityEngine;
using VContainer.Unity;

// ReSharper disable ClassNeverInstantiated.Global

namespace FPSShooter.Core.Utils
{
    public sealed class CursorToggler : IInitializable, IUpdateListener
    {
        public CursorToggler()
        {
        }
        
        public void Initialize()
        {
        }
        
        public void OnUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            { 
                Debug.Log("Cursor toggled");
                Cursor.visible = !Cursor.visible;
                Cursor.lockState = Cursor.visible ? CursorLockMode.None : CursorLockMode.Locked;
            }
        }

    }
}
