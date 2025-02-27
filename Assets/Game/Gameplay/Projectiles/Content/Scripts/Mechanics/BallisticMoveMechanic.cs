using FPSShooter.Modules.Core.GameLoop;
using FPSShooter.Modules.Gameplay.Projectiles;
using FPSShooter.Modules.Units;
using UnityEngine;

namespace FPSShooter.Game.Gameplay.Projectiles
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class BallisticMoveMechanic : IUnitMechanic, IFixedUpdateListener
    {
        private readonly Rigidbody _rigidbody;
        private readonly ProjectileConfig _config;
        private Vector3 _velocity;

        public BallisticMoveMechanic(Rigidbody rigidbody, ProjectileConfig config)
        {
            _rigidbody = rigidbody;
            _config = config;
        }

        public void OnFixedUpdate(float deltaTime)
        {
            // if (!_view.gameObject.activeSelf) return;
            //TODO: simplify
            
            _rigidbody.AddForce(Physics.gravity * _config.GravityMultiplier, ForceMode.Acceleration);
        }

        public void Initialize()
        {
            _rigidbody.mass = _config.Mass;
            _rigidbody.drag = _config.Drag;
            _rigidbody.velocity = _rigidbody.transform.forward * _config.InitialSpeed;
        }
    }
}