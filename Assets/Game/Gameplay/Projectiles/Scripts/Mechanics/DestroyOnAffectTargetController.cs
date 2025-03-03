using System;
using UnityEngine;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Projectiles
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class DestroyOnAffectTargetController : IInitializable, IDisposable
    {
        private readonly IAffectTargetMechanic _affectTargetMechanic;
        private readonly ProjectileDestroyMechanic _projectileDestroyMechanic;


        public DestroyOnAffectTargetController(IAffectTargetMechanic affectTargetMechanic, ProjectileDestroyMechanic projectileDestroyMechanic)
        {
            _affectTargetMechanic = affectTargetMechanic;
            _projectileDestroyMechanic = projectileDestroyMechanic;
        }

        public void Initialize()
        {
            _affectTargetMechanic.NotifyTargetAffectEnd += OnAffectTarget;
        }
        
        public void Dispose()
        {
            _affectTargetMechanic.NotifyTargetAffectEnd -= OnAffectTarget;
        }
        
        private void OnAffectTarget()
        {
            _projectileDestroyMechanic.Destroy();
        }
    }
}