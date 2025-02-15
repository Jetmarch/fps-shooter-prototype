using System;
using FPSShooter.Core.Managers;
using UnityEngine;
using VContainer.Unity;

namespace FPSShooter.Core.Systems
{
    [Serializable]
    public sealed class InputSystem : IUpdateListener, IInitializable
    {
        public event Action OnFire;
        public event Action OnStartAutomaticFire;
        public event Action OnEndAutomaticFire;
        public event Action OnReload;
        public event Action<Vector2> OnMove;
        public event Action<Vector2> OnLook;
        public event Action OnJump;
        public event Action OnMouseWheelUp;
        public event Action OnMouseWheelDown;
        
        private readonly InputConfig _inputConfig;

        public InputSystem(InputConfig inputConfig)
        {
            _inputConfig = inputConfig;
        }
        
        public void OnUpdate(float deltaTime)
        {
            ProcessInput();
        }
        
        public void Initialize()
        {
            //Non lazy
        }

        private void ProcessInput()
        {
            FireInput();
            AutomaticFireInput();
            ReloadInput();
            MoveInput();
            JumpInput();
            LookInput();
            MouseWheelInput();
        }

        private void FireInput()
        {
            if (Input.GetKeyDown(_inputConfig.Fire))
            {
                OnFire?.Invoke();
            }
        }

        private void AutomaticFireInput()
        {
            if (Input.GetKeyDown(_inputConfig.Fire))
            {
                OnStartAutomaticFire?.Invoke();
            }
            
            if (Input.GetKeyUp(_inputConfig.Fire))
            {
                OnEndAutomaticFire?.Invoke();
            }
        }

        private void ReloadInput()
        {
            if (Input.GetKeyDown(_inputConfig.Reload))
            {
                OnReload?.Invoke();
            }
        }

        private void MoveInput()
        {
            var moveVector = Vector2.zero;
            
            if (Input.GetKey(_inputConfig.MoveForward))
            {
                moveVector += Vector2.up;
            }

            if (Input.GetKey(_inputConfig.MoveBackward))
            {
                moveVector += Vector2.down;
            }

            if (Input.GetKey(_inputConfig.MoveRight))
            {
                moveVector += Vector2.right;
            }

            if (Input.GetKey(_inputConfig.MoveLeft))
            {
                moveVector += Vector2.left;
            }
            
            OnMove?.Invoke(moveVector);
        }

        private void JumpInput()
        {
            if (Input.GetKeyDown(_inputConfig.Jump))
            {
                OnJump?.Invoke();
            }
        }

        private void LookInput()
        {
            var mouseX = Input.GetAxis(_inputConfig.MouseX);
            var mouseY = Input.GetAxis(_inputConfig.MouseY);
            
            var lookVector = new Vector2(mouseX, mouseY);
            OnLook?.Invoke(lookVector);
        }

        private void MouseWheelInput()
        {
            var mouseScrollDelta = Input.GetAxis("Mouse ScrollWheel");
            if (mouseScrollDelta > 0)
            {
                Debug.Log($"mouse wheel up {mouseScrollDelta}");
                OnMouseWheelUp?.Invoke();
            }

            if (mouseScrollDelta < 0)
            {
                Debug.Log($"mouse wheel down {mouseScrollDelta}");
                OnMouseWheelDown?.Invoke();
            }
        }
    }
}
