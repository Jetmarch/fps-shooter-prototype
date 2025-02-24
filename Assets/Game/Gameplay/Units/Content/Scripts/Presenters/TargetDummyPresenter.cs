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
        private readonly ParticleType _deathParticle = ParticleType.LittleExplosionImpact;
        
        private readonly Animator _animator;
        private readonly int _hitTrigger = Animator.StringToHash("Hit");
        private readonly int _deathTrigger = Animator.StringToHash("Death");

        public TargetDummyPresenter(UnitView view, ObjectState objectState, IParticlesManager particlesManager, ParticleType hitParticle, Animator animator)
        {
            _view = view;
            _objectState = objectState;
            _particlesManager = particlesManager;
            _hitParticle = hitParticle;
            _objectState.Initialize();
            _animator = animator;
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
            _objectState.Affect(impact);
            _particlesManager?.SpawnParticles(_hitParticle, impact.HitPoint, impact.HitRotation);
            _animator.SetTrigger(_hitTrigger);
        }

        public void Die()
        {
            // Object.Destroy(_view.gameObject);
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

        public void TearApartDeath()
        {
            _particlesManager?.SpawnParticles(_deathParticle, _view.transform.position, _view.transform.rotation);
            _animator.SetTrigger(_deathTrigger);
        }
    }
}