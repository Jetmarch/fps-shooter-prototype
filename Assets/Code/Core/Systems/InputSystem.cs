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
        public event Action<Vector2> OnMove;
        public event Action<Vector2> OnLook;
        public event Action OnJump;
        
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
            MoveInput();
            JumpInput();
            LookInput();
        }

        private void FireInput()
        {
            if (Input.GetKeyDown(_inputConfig.Fire))
            {
                OnFire?.Invoke();
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
            var horizontalAxis = Input.GetAxis(_inputConfig.HorizontalAxis);
            var verticalAxis = Input.GetAxis(_inputConfig.VerticalAxis);
            var lookVector = new Vector2(horizontalAxis, verticalAxis);
            OnLook?.Invoke(lookVector);
        }

        
    }
}
