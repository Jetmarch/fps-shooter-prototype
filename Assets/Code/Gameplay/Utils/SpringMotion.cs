using System;
using UnityEngine;
// ReSharper disable ClassNeverInstantiated.Global

namespace FPSShooter.Gameplay.Utils
{
    [Serializable]
    public sealed class SpringMotion
    {
        [SerializeField] private Transform _target;
        
        private SpringMotionSettings _springMotionSettings;
        private Vector3 _springPosition;
        private Vector3 _springVelocity;

        public SpringMotion(Transform target, SpringMotionSettings springMotionSettings)
        {
            _target = target;
            _springMotionSettings = springMotionSettings;
            _springPosition = _target.position;
            _springVelocity = Vector3.zero;
        }

        public void UpdateSpring(float deltaTime, Vector3 up)
        {
            _target.localPosition = Vector3.zero;

            Spring(ref _springPosition, ref _springVelocity, _target.position, _springMotionSettings.HalfLife, _springMotionSettings.Frequency, deltaTime);

            var localSpringPosition = _springPosition - _target.position;
            var springHeight = Vector3.Dot(localSpringPosition, up);
            var xRot = _target.localEulerAngles.x + -springHeight * _springMotionSettings.AngularDisplacement;
            _target.localEulerAngles = new Vector3(xRot, _target.localEulerAngles.y, _target.localEulerAngles.z);
            _target.localPosition = localSpringPosition * _springMotionSettings.LinearDisplacement;
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
