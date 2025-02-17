using System;
using FPSShooter.Modules.Core.GameLoop;
using UnityEngine;
using VContainer;

namespace FPSShooter.Modules.Gameplay.Projectiles
{
    public sealed class ProjectileView : MonoBehaviour, IFixedUpdateListener
    {
        public ProjectileType ProjectileType => _presenter.GetProjectileType();
        public event Action<ProjectileView> OnProjectileDestroyed;
        public Rigidbody Rigidbody => _rigidbody;
        
        [SerializeField] private ParticleSystem _moveVFX;
        [SerializeField] private ParticleSystem _hitVFX;
        [SerializeField] private Rigidbody _rigidbody;

        private IProjectilePresenter _presenter;

        [Inject]
        private void Configure(IProjectilePresenter presenter)
        {
            _presenter = presenter;
        }
        
        private void OnCollisionEnter(Collision other)
        {
            var hitPoint = other.contacts[0].point;
            var hitNormal = other.contacts[0].normal;
            _presenter.Hit(other.gameObject, hitPoint, hitNormal);
        }

        public void Initialize()
        {
            _presenter.Initialize();
        }
        
        public void OnFixedUpdate(float deltaTime)
        {
            _presenter.Update(deltaTime);
        }

        public void NotifyProjectileDestroyed()
        {
            OnProjectileDestroyed?.Invoke(this);
        }

        public void PlayMoveVFX()
        {
            _moveVFX.Play();
        }

        public void PlayHitVFX()
        {
            _hitVFX.Play();
        }
    }
}