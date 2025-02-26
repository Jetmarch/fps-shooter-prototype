using System;
using System.Collections.Generic;
using FPSShooter.Core.Managers;
using FPSShooter.Modules.Gameplay.Impact;
using FPSShooter.Modules.Gameplay.Weapons;
using FPSShooter.Modules.Units;
using UnityEngine;

namespace FPSShooter.Game.Gameplay.Units.Player
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class TargetDummyPresenter : IUnitPresenter
    {
        private readonly UnitView _view;
        private readonly ObjectState _objectState;
        private readonly IParticlesManager _particlesManager;
        private readonly ParticleType _hitParticle;
        private readonly ParticleType _deathParticles = ParticleType.TearApartDeath;
        private readonly ParticleType _resurrectParticles = ParticleType.Resurrection;
        
        private readonly Animator _animator;
        private readonly int _hitTrigger = Animator.StringToHash("Hit");
        private readonly int _deathTrigger = Animator.StringToHash("Death");
        
        private readonly Collider _collider;

        private readonly List<IUnitMechanic> _unitLogic;

        public TargetDummyPresenter(UnitView view, ObjectState objectState, IParticlesManager particlesManager, ParticleType hitParticle, Animator animator, Collider collider)
        {
            _view = view;
            _objectState = objectState;
            _particlesManager = particlesManager;
            _hitParticle = hitParticle;
            _objectState.Initialize();
            _animator = animator;
            _collider = collider;
        }

        public void Affect(ImpactData impact)
        {
            if (_objectState.IsDead) return;
            
            _objectState.Affect(impact);
            _particlesManager?.SpawnParticles(_hitParticle, impact.HitPoint, impact.HitRotation);
            _animator.SetTrigger(_hitTrigger);
        }

        public void Die()
        {
            _collider.enabled = false;
            _animator.SetTrigger(_deathTrigger);
        }

        public ObjectState GetObjectStateData()
        {
            return _objectState;
        }

        public void Resurrect()
        {
            _objectState.Initialize();
            _animator.Rebind();
            _animator.Update(0f);
            _collider.enabled = true;
            _particlesManager?.SpawnParticles(_resurrectParticles, _view.transform.position, _view.transform.rotation);
        }

        public IUnitMechanic GetLogic<T>()
        {
            throw new NotImplementedException();
        }

        public void AddLogic(IUnitMechanic mechanic)
        {
            throw new NotImplementedException();
        }

        public List<IUnitMechanic> UnitMechanics { get; }


        public void TearApartDeath()
        {
            _particlesManager?.SpawnParticles(_deathParticles, _view.transform.position, _view.transform.rotation);
            Die();
        }

        T IUnitPresenter.GetLogic<T>()
        {
            throw new NotImplementedException();
        }
    }
}