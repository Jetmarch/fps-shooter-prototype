using System;
using UnityEngine;

namespace FPSShooter.Gameplay.Units
{
    //TODO: include in player config
    [Serializable]
    public sealed class HandsWobbleAnimation
    {
        [SerializeField] private Transform _playerHands;
        private HandsWobbleAnimationData _data;

        private float _wobbleTime;
        private Vector3 _lastPlayerMoveInput;
        private Vector3 _initialHandsPosition;
        private Quaternion _initialHandsRotation;

        public HandsWobbleAnimation(Transform playerHands, HandsWobbleAnimationData data)
        {
            _playerHands = playerHands;
            _data = data;
            _initialHandsPosition = _playerHands.localPosition;
            _initialHandsRotation = _playerHands.localRotation;
        }
        
        public void UpdateInput(Vector2 movementVector)
        {
            _lastPlayerMoveInput = movementVector;
        }
        
        public void Update(float deltaTime)
        {
            WobbleHands(deltaTime);
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
                    // Mathf.Sin(_wobbleTime) * currentPositionWobbleStrength,
                    0f);

                var rotationWobble = new Vector3(
                    Mathf.Sin(_wobbleTime) * currentRotationWobbleStrength,
                    Mathf.Sin(_wobbleTime * 0.5f) * currentRotationWobbleStrength,
                    Mathf.Cos(_wobbleTime) * currentRotationWobbleStrength);

                _playerHands.localPosition = Vector3.Lerp(_playerHands.localPosition, _initialHandsPosition + positionWobble, _data.WobbleSmoothness * deltaTime);
                // _cameraTarget.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(rotationWobble) * _initialHandsRotation, _wobbleSmoothnes * deltaTime);
            }
            else
            {
                _playerHands.localPosition = Vector3.Lerp(_playerHands.localPosition, _initialHandsPosition, _data.WobbleSmoothness * deltaTime);
                _wobbleTime = 0f;
            }
        }
    }

    [Serializable]
    public sealed class HandsWobbleAnimationData
    {
        [SerializeField] private float _wobbleSpeed = 1;
        [SerializeField] private float _positionWobbleStrength = 0.1f;
        [SerializeField] private float _rotationWobbleStrength = 0.5f;
        [SerializeField] private float _wobbleSmoothness = 5f;
        
        public float WobbleSpeed => _wobbleSpeed;
        public float PositionWobbleStrength => _positionWobbleStrength;
        public float RotationWobbleStrength => _rotationWobbleStrength;
        public float WobbleSmoothness => _wobbleSmoothness;
    }
}