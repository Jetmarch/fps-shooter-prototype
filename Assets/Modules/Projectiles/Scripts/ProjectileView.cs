using System;
using UnityEngine;
using VContainer;

namespace FPSShooter.Modules.Gameplay.Projectiles
{
    public sealed class ProjectileView : MonoBehaviour
    {
        public ProjectileType ProjectileType => _presenter.GetProjectileType();
        public event Action<ProjectileView> OnProjectileDestroyed;
        public Rigidbody Rigidbody => _rigidbody;
        
        [SerializeField] private ParticleSystem _moveVFX;
        [SerializeField] private Rigidbody _rigidbody;

        private IProjectilePresenter _presenter;

        [Inject]
        private void Configure(IProjectilePresenter presenter)
        {
            _presenter = presenter;
        }
        
        private void OnCollisionEnter(Collision other)
        {
            _presenter.Hit(other);
        }

        public void Initialize()
        {
            _presenter.Initialize();
        }

        public void NotifyProjectileDestroyed()
        {
            OnProjectileDestroyed?.Invoke(this);
        }

        public void PlayMoveVFX()
        {
            _moveVFX.Play();
        }
    }
}