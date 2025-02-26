using FPSShooter.Core.Managers;
using FPSShooter.Modules.Gameplay.Impact;
using FPSShooter.Modules.Units;
using UnityEngine;

namespace FPSShooter.Game.Gameplay.Units.UnitLogic
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class HitMechanic : IUnitMechanic
    {
        private readonly IParticlesManager _particlesManager;
        private readonly Animator _animator;
        private readonly int _hitTrigger = Animator.StringToHash("Hit");
        private readonly ParticleType _hitParticle = ParticleType.BloodImpact;
        private readonly ObjectStateMechanic _objectStateMechanic;

        public HitMechanic(IParticlesManager particlesManager, Animator animator, ObjectStateMechanic objectStateMechanic)
        {
            _particlesManager = particlesManager;
            _animator = animator;
            _objectStateMechanic = objectStateMechanic;
        }

        public void Hit(ImpactData impact)
        {
            if (_objectStateMechanic.IsDead) return;
            
            _objectStateMechanic.Affect(impact);
            _particlesManager?.SpawnParticles(_hitParticle, impact.HitPoint, impact.HitRotation);
            _animator.SetTrigger(_hitTrigger);
        }
    }
}