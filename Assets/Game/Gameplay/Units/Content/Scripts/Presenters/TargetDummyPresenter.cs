using FPSShooter.Core.Managers;
using FPSShooter.Modules.Gameplay.Impact;
using FPSShooter.Modules.Gameplay.Weapons;
using FPSShooter.Modules.Units;
using Modules.Units.Scripts.Presenters;
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
        
        public void Shoot()
        {
            //Not used
        }

        public void ShootStartAutomatic()
        {
            //Not used
        }

        public void ShootEndAutomatic()
        {
            //Not used
        }

        public void Reload()
        {
            //Not used
        }

        public void Move(Vector2 movementVector)
        {
            //Not used
        }

        public void Look(Vector2 lookVector)
        {
            //Not used
        }

        public void RequestJump()
        {
            //Not used
        }

        public void AddWeapon(IWeapon weapon)
        {
            //Not used
        }

        public void SetNextWeapon()
        {
            //Not used
        }

        public void SetPreviousWeapon()
        {
            //Not used
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

        public void Update(float deltaTime)
        {
            //Not used
        }

        public void Resurrect()
        {
            _objectState.Initialize();
            _animator.Rebind();
            _animator.Update(0f);
            _collider.enabled = true;
            _particlesManager?.SpawnParticles(_resurrectParticles, _view.transform.position, _view.transform.rotation);
        }

        public void TearApartDeath()
        {
            _particlesManager?.SpawnParticles(_deathParticles, _view.transform.position, _view.transform.rotation);
            Die();
        }
    }
}