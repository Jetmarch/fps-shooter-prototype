using FPSShooter.Gameplay.Projectiles;
using UnityEngine;

namespace FPSShooter.Gameplay.Weapons
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class ProjectileWeaponPresenter : IWeaponPresenter
    {
        private readonly WeaponView _view;
        private readonly Weapon _model;
        private readonly IProjectileManager _projectileManager;
        
        public ProjectileWeaponPresenter(WeaponView view, Weapon model, IProjectileManager projectileManager)
        {
            _view = view;
            _model = model;
            _projectileManager = projectileManager;
        }
        
        public void Shoot()
        {
            if (!_model.CanShoot())
            {
                //TODO: click sound
                Debug.Log("Weapon cannot shoot");
                return;
            }
            
            //TODO: pass impactRequest, position and rotation to projectileManager
            _projectileManager.CreateProjectile(_view.ShootPoint);
            _view.Recoil();
            //newProjectile.SetImpactRequest(_model.ImpactRequest);
        }

        public void Reload()
        {
            if (!_model.TryReload()) return;
            //TODO: show reload animation
            //_view.Reload();
        }
    }
}
