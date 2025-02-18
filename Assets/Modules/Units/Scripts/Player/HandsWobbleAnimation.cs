using System;
using FPSShooter.Modules.Core.GameLoop;
using UnityEngine;

namespace FPSShooter.Modules.Units
{
    [Serializable]
    public sealed class HandsWobbleAnimation : ILateUpdateListener
    {
        [SerializeField] private Transform _playerHands;
        private HandsWobbleAnimationData _data;

        private float _wobbleTime;
        private Vector3 _lastPlayerMoveInput;
        private Vector3 _initialHandsPosition;

        public HandsWobbleAnimation(Transform playerHands, HandsWobbleAnimationData data)
        {
            _playerHands = playerHands;
            _data = data;
            _initialHandsPosition = _playerHands.localPosition;
        }
        
        public void OnLook(Vector2 movementVector)
        {
            _lastPlayerMoveInput = movementVector;
        }
        
        private void WobbleHands(float deltaTime)
        {
            bool isMoving = _lastPlayerMoveInput.x != 0 || _lastPlayerMoveInput.y != 0;

            if (isMoving)
            {
                _wobbleTime += deltaTime * _data.WobbleSpeed;

                var inputMagnitude = _lastPlayerMoveInput.magnitude;
                
                var currentPositionWobbleStrength = _data.PositionWobbleStrength * inputMagnitude;
                var currentRotationWobbleStrength = _data.RotationWobbleStrength * inputMagnitude;

                var positionWobble = new Vector3(
                    Mathf.Sin(_wobbleTime * 2f) * currentPositionWobbleStrength,
                    0f);

                _playerHands.localPosition = Vector3.Lerp(_playerHands.localPosition, _initialHandsPosition + positionWobble, _data.WobbleSmoothness * deltaTime);
            }
            else
            {
                _playerHands.localPosition = Vector3.Lerp(_playerHands.localPosition, _initialHandsPosition, _data.WobbleSmoothness * deltaTime);
                _wobbleTime = 0f;
            }
        }

        public void OnLateUpdate(float deltaTime)
        {
            WobbleHands(deltaTime);
        }
    }
}