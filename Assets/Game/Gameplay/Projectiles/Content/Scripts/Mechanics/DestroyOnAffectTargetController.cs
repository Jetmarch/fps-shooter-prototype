using System;
using UnityEngine;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Projectiles
{
    public sealed class DestroyOnAffectTargetController : IInitializable, IDisposable
    {
        private readonly AffectTargetMechanic _affectTargetMechanic;
        private readonly DestroyMechanic _destroyMechanic;


        public DestroyOnAffectTargetController(AffectTargetMechanic affectTargetMechanic, DestroyMechanic destroyMechanic)
        {
            _affectTargetMechanic = affectTargetMechanic;
            _destroyMechanic = destroyMechanic;
        }

        public void Initialize()
        {
            _affectTargetMechanic.NotifyAffectTarget += OnAffectTarget;
        }
        
        public void Dispose()
        {
            _affectTargetMechanic.NotifyAffectTarget -= OnAffectTarget;
        }
        
        private void OnAffectTarget(GameObject obj)
        {
            _destroyMechanic.Destroy();
        }
    }
}