using System;
using FPSShooter.Modules.Gameplay.Projectiles;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Projectiles
{
    public sealed class BulletCollisionController : IInitializable, IDisposable
    {
        private readonly AffectTargetMechanic _affectTargetMechanic;
        private readonly CollisionDetectorComponent _collisionDetector;

        public BulletCollisionController(AffectTargetMechanic affectTargetMechanic, CollisionDetectorComponent collisionDetector)
        {
            _affectTargetMechanic = affectTargetMechanic;
            _collisionDetector = collisionDetector;
        }

        public void Initialize()
        {
            _collisionDetector.CollisionEnter += _affectTargetMechanic.AffectTarget;
        }

        public void Dispose()
        {
            _collisionDetector.CollisionEnter -= _affectTargetMechanic.AffectTarget;
            
        }
    }
}