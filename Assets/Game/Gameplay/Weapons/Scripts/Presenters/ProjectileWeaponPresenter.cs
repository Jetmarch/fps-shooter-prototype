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
        private bool _isAutomaticFire;
        
        public ProjectileWeaponPresenter(WeaponView view, Weapon model, IProjectileManager projectileManager)
        {
            _view = view;
            _model = model;
            _projectileManager = projectileManager;
        }
        
        public void Shoot()
        {
            if (_model.IsDelayBetweenShots())
            {
                return;
            }
            
            if (_model.IsReloading())
            {
                return;
            }
            
            if (_model.NeedToReload())
            {
                //TODO: click sound
                Reload();
                return;
            }

            _projectileManager.CreateProjectile(_view.ShootPoint);
            _view.Recoil();
            _view.PlayShotVFX();
            
            _model.SetCurrentAmmo(_model.CurrentAmmo - 1);
            _model.SetShootDelay();
        }

        public void StartShootAutomatic()
        {
            _isAutomaticFire = true;
            Debug.Log("Start automatic fire");
        }

        public void EndShootAutomatic()
        {
            _isAutomaticFire = false;
            Debug.Log("End automatic fire");
        }

        public void Reload()
        {
            if (!_model.TryReload()) return;
            //TODO: show reload animation
            //_view.Reload();
        }

        public void Update(float deltaTime)
        {
            _model.UpdateShootDelay(deltaTime);
            _model.UpdateReloadDelay(deltaTime);

            if (_isAutomaticFire)
            {
                Shoot();
            }
        }
    }
}
