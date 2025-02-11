using FPSShooter.Gameplay.Projectiles;

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
                return;
            }
            
            //TODO: pass impactRequest, position and rotation to projectileManager
            var newProjectile = _projectileManager.GetProjectile();
            newProjectile.transform.position = _view.ShootPoint.position;
            newProjectile.transform.rotation = _view.ShootPoint.rotation;
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
