using Audio;
using FPSShooter.Modules.Core.GameLoop;
using FPSShooter.Modules.Gameplay.Projectiles;

namespace FPSShooter.Modules.Gameplay.Weapons
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class ProjectileWeaponPresenter : IWeaponPresenter, IUpdateListener
    {
        private readonly WeaponView _view;
        private readonly Weapon _model;
        private readonly IProjectileManager _projectileManager;
        //TODO: move to model
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

            _projectileManager.CreateProjectile(_model.ProjectileType, _view.ShootPoint);
            _view.Recoil();
            _view.PlayShotVFX();


            TryPlaySound(_model.ShootSoundName);

            _model.SetCurrentAmmo(_model.CurrentAmmo - 1);
            _model.SetShootDelay();
        }

        public void StartShootAutomatic()
        {
            _isAutomaticFire = true;
        }

        public void EndShootAutomatic()
        {
            _isAutomaticFire = false;
        }

        public void Reload()
        {
            if (!_model.TryReload()) return;
            //TODO: show reload animation
            TryPlaySound(_model.ReloadSoundName);
            //_view.Reload();
        }
        
        private void TryPlaySound(string soundName)
        {
            if (AudioManager.Instance.TryGetAudioClipByName(soundName, out var audioClip))
            {
                AudioManager.Instance.PlaySoundOneShot(audioClip, AudioOutput.Master, pitch: UnityEngine.Random.Range(0.7f, 1f));
            }
        }

        public void OnUpdate(float deltaTime)
        {
            if (!_view.gameObject.activeSelf) return;
            
            _model.UpdateShootDelay(deltaTime);
            _model.UpdateReloadDelay(deltaTime);

            if (_isAutomaticFire && _model.IsAutomatic)
            {
                Shoot();
            }
        }
    }
}
