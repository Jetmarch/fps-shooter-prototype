using System;
using UnityEngine;
using UnityEngine.Serialization;

// ReSharper disable ClassNeverInstantiated.Global

namespace FPSShooter.Modules.Utils
{
    [Serializable]
    public sealed class SpringMotion
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Transform _follower;
        
        private SpringMotionSettings _springMotionSettings;
        private Vector3 _springPosition;
        private Vector3 _springVelocity;

        public SpringMotion(Transform target, Transform follower, SpringMotionSettings springMotionSettings)
        {
            _target = target;
            _follower = follower;
            _springMotionSettings = springMotionSettings;
            _springPosition = _follower.position;
            _springVelocity = Vector3.zero;
        }

        public void UpdateSpring(float deltaTime, Vector3 up)
        {
            _follower.position = _target.position;

            Spring(ref _springPosition, ref _springVelocity, _target.position, _springMotionSettings.HalfLife, _springMotionSettings.Frequency, deltaTime);

            var springPositionDiff = _springPosition - _target.position;
            var springHeight = Vector3.Dot(springPositionDiff, up);
            var xRot = _follower.eulerAngles.x + -springHeight * _springMotionSettings.AngularDisplacement;
            _follower.eulerAngles += new Vector3(xRot, _follower.eulerAngles.y, _follower.eulerAngles.z);
            _follower.position += springPositionDiff * _springMotionSettings.LinearDisplacement;
        }

        // https://allenchou.net/2015/04/game-math-more-on-numeric-springing/
        private static void Spring(ref Vector3 current, ref Vector3 velocity, Vector3 target, float halfLife, float frequency, float timeStep)
        {
            var dampingRatio = -Mathf.Log(0.5f) / (frequency * halfLife);
            var f = 1.0f + 2.0f * timeStep * dampingRatio * frequency;
            var oo = frequency * frequency;
            var hoo = timeStep * oo;
            var hhoo = timeStep * hoo;
            var detInv = 1.0f / (f + hhoo);
            var detX = f * current + timeStep * velocity + hhoo * target;
            var detV = velocity + hoo * (target - current);
            current = detX * detInv;
            velocity = detV * detInv;
        }
    }
}
