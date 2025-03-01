using Audio;
using FPSShooter.Game.Gameplay.Units;
using FPSShooter.Game.Gameplay.Weapons;
using FPSShooter.Modules.Core.GameLoop;
using FPSShooter.Modules.Gameplay.Projectiles;
using FPSShooter.Modules.Meta.Upgrades;
using FPSShooter.Modules.Meta.Upgrades.UI;
using UnityEngine;

namespace FPSShooter.Modules.Gameplay.Weapons
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class ProjectileWeaponPresenter : IWeaponPresenter, IUpdateListener, IPauseListener
    {
        private readonly WeaponView _view;
        private readonly HolographicAmmoDisplay _ammoDisplay;
        private readonly Weapon _model;
        private readonly IProjectileManager _projectileManager;
        private readonly Animator _animator;
        private readonly Upgrade[] _availableUpgrades;
        
        //TODO: move to model
        private bool _isAutomaticFire;
        
        private int _reloadAnimation = Animator.StringToHash("Reload");
        private int _pullOutAnimation = Animator.StringToHash("PullOut");
        private int _putAwayAnimation = Animator.StringToHash("PutAway");
        private int _upgradingAnimation = Animator.StringToHash("IsInspecting");
        private int _reloadSpeedMultiplier = Animator.StringToHash("ReloadSpeedMultiplier");
        
        public ProjectileWeaponPresenter(WeaponView view, Weapon model, IProjectileManager projectileManager, HolographicAmmoDisplay ammoDisplay, Animator animator, UpgradeFactory upgradeFactory)
        {
            _view = view;
            _model = model;
            _projectileManager = projectileManager;
            _ammoDisplay = ammoDisplay;
            _animator = animator;
            _availableUpgrades = upgradeFactory.CreateUpgrades();
            UpdateAmmoDisplay();
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
            _projectileManager.CreateProjectile(_model.ProjectileType, _view.ShootPoint);
            
            _model.SetCurrentAmmo(_model.CurrentAmmo - 1);
            _model.SetShootDelay();
            
            _view.Recoil();
            _view.PlayShotVFX();
            TryPlaySound(_model.ShootSoundName);
            UpdateAmmoDisplay();
            
            if (_model.NeedToReload())
            {
                //TODO: click sound
                Reload();
            }
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
            TryPlaySound(_model.ReloadSoundName);
            _animator.SetTrigger(_reloadAnimation);
            UpdateAmmoDisplay();
        }

        public void PullOut()
        {
            _animator.SetTrigger(_pullOutAnimation);
            _animator.SetFloat(_reloadSpeedMultiplier, 1 / _model.ReloadDelay.MaxValue);
        }

        public void PutAway()
        {
            _animator.SetTrigger(_putAwayAnimation);
        }

        public void StartUpgrading()
        {
            _animator.SetBool(_upgradingAnimation, true);
        }

        public void StopUpgrading()
        {
            _animator.SetBool(_upgradingAnimation, false);
            _animator.SetFloat(_reloadSpeedMultiplier, 1 / _model.ReloadDelay.MaxValue);
            UpdateAmmoDisplay();
        }

        public Upgrade[] GetAvailableUpgrades()
        {
            return _availableUpgrades;
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
        
        private void TryPlaySound(string soundName)
        {
            if (AudioManager.Instance.TryGetAudioClipByName(soundName, out var audioClip))
            {
                AudioManager.Instance.PlaySoundOneShot(audioClip, AudioOutput.Master, pitch: UnityEngine.Random.Range(0.7f, 1f));
            }
        }

        private void UpdateAmmoDisplay()
        {
            var ammoText = $"{_model.CurrentAmmo.ToString()}/{_model.MaxAmmo.ToString()}";
            _ammoDisplay.SetText(ammoText);
        }

        public void OnPause()
        {
            _animator.speed = 0f;
        }

        public void OnResume()
        {
            _animator.speed = 1f;
        }
    }
}
