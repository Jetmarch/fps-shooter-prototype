using FPSShooter.Core.Managers;
using FPSShooter.Modules.Gameplay.Impact;
using FPSShooter.Modules.Units;
using UnityEngine;

namespace FPSShooter.Game.Gameplay.Units.UnitLogic
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class DieMechanic : IUnitMechanics
    {
        private readonly Animator _animator;
        private readonly int _deathTrigger = Animator.StringToHash("Death");
        private readonly Collider _collider;

        public DieMechanic(Animator animator, Collider collider)
        {
            _animator = animator;
            _collider = collider;
        }

        public void Die()
        {
            _collider.enabled = false;
            _animator.SetTrigger(_deathTrigger);
        }
    }

    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class ResurrectMechanic : IUnitMechanics
    {
        private readonly ObjectStateMechanic _objectStateMechanic;
        private readonly Animator _animator;
        private readonly Collider _collider;
        private readonly ParticleType _resurrectParticles = ParticleType.Resurrection;
        private readonly UnitView _view;
        private readonly IParticlesManager _particlesManager;

        public ResurrectMechanic(ObjectStateMechanic objectStateMechanic, Animator animator, Collider collider, UnitView view, IParticlesManager particlesManager)
        {
            _objectStateMechanic = objectStateMechanic;
            _animator = animator;
            _collider = collider;
            _view = view;
            _particlesManager = particlesManager;
        }

        public void Resurrect()
        {
            _objectStateMechanic.Initialize();
            _animator.Rebind();
            _animator.Update(0f);
            _collider.enabled = true;
            _particlesManager?.SpawnParticles(_resurrectParticles, _view.transform.position, _view.transform.rotation);
        }
    }

    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class HitMechanic : IUnitMechanics
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