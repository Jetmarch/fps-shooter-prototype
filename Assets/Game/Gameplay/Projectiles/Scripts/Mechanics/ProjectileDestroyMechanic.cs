using System;
using FPSShooter.Core.Managers;
using FPSShooter.Game.Gameplay.Units.UnitLogic;
using FPSShooter.Modules.Gameplay.Projectiles;
using FPSShooter.Modules.Units;
using UnityEngine;

namespace FPSShooter.Game.Gameplay.Projectiles
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class ProjectileDestroyMechanic : IUnitMechanic
    {
        public event Action<GameObject> NotifyProjectileDestroyed;
        
        private readonly UnitView _view;
        private readonly SoundPlayer _soundPlayer;
        private readonly ProjectileConfig _config;
        private readonly IParticlesManager _particlesManager;
        public ProjectileDestroyMechanic(UnitView view, SoundPlayer soundPlayer, IParticlesManager particlesManager, ProjectileConfig config)
        {
            _view = view;
            _soundPlayer = soundPlayer;
            _particlesManager = particlesManager;
            _config = config;
        }
        
        public void Destroy()
        {
            _soundPlayer.TryPlaySound(_config.DestroySound);
            _particlesManager.SpawnParticles(_config.DestroyParticle, _view.transform.position, _view.transform.rotation);
            NotifyProjectileDestroyed?.Invoke(_view.gameObject);
        }
    }
}