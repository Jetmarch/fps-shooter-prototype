using System;
using UnityEngine;

namespace FPSShooter.Core.Systems
{
    public interface IInputSystem
    {
        public event Action OnUpgrades;
        public event Action OnMenu;
        public event Action OnFire;
        public event Action OnStartAutomaticFire;
        public event Action OnEndAutomaticFire;
        public event Action OnReload;
        public event Action<Vector2> OnMove;
        public event Action<Vector2> OnLook;
        public event Action OnJump;
        public event Action OnMouseWheelUp;
        public event Action OnMouseWheelDown;
    }
}