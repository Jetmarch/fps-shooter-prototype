using FPSShooter.Modules.Core.GameLoop;
using UnityEngine;

namespace FPSShooter.Modules.Utils
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class ObjectRotator : IUpdateListener
    {
        private readonly Transform _transform;
        private readonly float _speed;

        public ObjectRotator(Transform transform, float speed)
        {
            _transform = transform;
            _speed = speed;
        }

        public void OnUpdate(float deltaTime)
        {
            _transform.Rotate(Vector3.up, _speed * deltaTime);
        }
    }
}