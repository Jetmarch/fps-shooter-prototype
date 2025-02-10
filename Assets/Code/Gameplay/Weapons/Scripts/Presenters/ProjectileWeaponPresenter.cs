using UnityEngine;

namespace FPSShooter.Gameplay.Weapons
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class ProjectileWeaponPresenter : IWeaponPresenter
    {
        private readonly WeaponView _view;
        private readonly Weapon _model;
        //private ProjectileFactory _projectileFactory;

        public ProjectileWeaponPresenter(WeaponView view, Weapon model)
        {
            _view = view;
            _model = model;
        }
        
        public void Shoot()
        {
            if (!_model.CanShoot())
            {
                //TODO: click sound
                return;
            }
            
            //TODO: use _projectileFactory
            var newProjectile = Object.Instantiate(_model.ProjectilePrefab, _view.ShootPoint.position, _view.ShootPoint.rotation);
        }

        public void Reload()
        {
            if (!_model.TryReload()) return;
            //TODO: show reload animation
            //_view.Reload();
        }
    }
}
