using System;
using UnityEngine;

namespace FPSShooter.Gameplay.Units
{
    //TODO: include in player config
    [Serializable]
    public sealed class HandsWobbleAnimation
    {
        [SerializeField] private Transform _playerHands;
        [SerializeField] private float _wobbleTime;
        [SerializeField] private float _wobbleSpeed = 1;
        [SerializeField] private float _positionWobbleStrength = 0.1f;
        [SerializeField] private float _rotationWobbleStrength = 0.5f;
        [SerializeField] private float _wobbleSmoothness = 5f;

        private Vector3 _lastPlayerMoveInput;
        
        private Vector3 _initialHandsPosition;
        private Quaternion _initialHandsRotation;

        public HandsWobbleAnimation(Transform playerHands)
        {
            _playerHands = playerHands;
            _initialHandsPosition = _playerHands.localPosition;
            _initialHandsRotation = _playerHands.localRotation;
        }
        
        public void OnPlayerMove(Vector2 movementVector)
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
                _wobbleTime += deltaTime * _wobbleSpeed;

                var inputMagnitude = _lastPlayerMoveInput.magnitude;
                
                var currentPositionWobbleStrength = _positionWobbleStrength * inputMagnitude;
                var currentRotationWobbleStrength = _rotationWobbleStrength * inputMagnitude;

                var positionWobble = new Vector3(
                    Mathf.Sin(_wobbleTime * 2f) * currentPositionWobbleStrength,
                    // Mathf.Sin(_wobbleTime) * currentPositionWobbleStrength,
                    0f);

                var rotationWobble = new Vector3(
                    Mathf.Sin(_wobbleTime) * currentRotationWobbleStrength,
                    Mathf.Sin(_wobbleTime * 0.5f) * currentRotationWobbleStrength,
                    Mathf.Cos(_wobbleTime) * currentRotationWobbleStrength);

                _playerHands.localPosition = Vector3.Lerp(_playerHands.localPosition, _initialHandsPosition + positionWobble, _wobbleSmoothness * deltaTime);
                // _cameraTarget.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(rotationWobble) * _initialHandsRotation, _wobbleSmoothnes * deltaTime);
            }
            else
            {
                _playerHands.localPosition = Vector3.Lerp(_playerHands.localPosition, _initialHandsPosition, _wobbleSmoothness * deltaTime);
                _wobbleTime = 0f;
            }
        }

        
    }
}