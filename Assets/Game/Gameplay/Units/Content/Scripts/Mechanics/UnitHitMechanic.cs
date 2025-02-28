using FPSShooter.Core.Managers;
using FPSShooter.Modules.Gameplay.Impact;
using FPSShooter.Modules.Units;
using UnityEngine;

namespace FPSShooter.Game.Gameplay.Units.UnitLogic
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class UnitHitMechanic : IUnitMechanic
    {
        private readonly IParticlesManager _particlesManager;
        private readonly Animator _animator;
        private readonly ObjectStateMechanic _objectStateMechanic;
        private readonly SoundPlayer _soundPlayer;
        private readonly int _hitTrigger = Animator.StringToHash("Hit");
        private readonly string _hitParticle = "boneExplosion";
        private readonly string _hitSound = "dummyHit";

        public UnitHitMechanic(IParticlesManager particlesManager, Animator animator, ObjectStateMechanic objectStateMechanic, SoundPlayer soundPlayer)
        {
            _particlesManager = particlesManager;
            _animator = animator;
            _objectStateMechanic = objectStateMechanic;
            _soundPlayer = soundPlayer;
        }

        public void Hit(ImpactData impact)
        {
            if (_objectStateMechanic.IsDead) return;
            
            _objectStateMechanic.Affect(impact);
            _particlesManager?.SpawnParticles(_hitParticle, impact.HitPoint, impact.HitRotation);
            _animator.SetTrigger(_hitTrigger);
            _soundPlayer.TryPlaySound(_hitSound);
        }
    }
}