using System;
using FPSShooter.Modules.Gameplay.Projectiles;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Projectiles
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class ProjectileCollisionController : IInitializable, IDisposable
    {
        private readonly IAffectTargetMechanic _affectTargetMechanic;
        private readonly CollisionDetectorComponent _collisionDetector;

        public ProjectileCollisionController(IAffectTargetMechanic affectTargetMechanic, CollisionDetectorComponent collisionDetector)
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