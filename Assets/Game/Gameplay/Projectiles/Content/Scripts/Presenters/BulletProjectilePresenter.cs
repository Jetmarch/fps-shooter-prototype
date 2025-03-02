
using FPSShooter.Modules.Gameplay.Projectiles;
using FPSShooter.Modules.Utils;
using UnityEngine;

namespace FPSShooter.Game.Gameplay.Projectiles
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class BulletProjectilePresenter : IProjectilePresenter
    {
        private readonly CollisionDetectorComponent _view;
        private readonly ProjectileConfig _config;

        private Vector3 _velocity;

        public BulletProjectilePresenter(CollisionDetectorComponent view, ProjectileConfig config)
        {
            _view = view;
            _config = config;
        }
        //
        // public void Initialize()
        // {
        //     _view.PlayMoveVFX();
        //     _view.Rigidbody.mass = _config.Mass;
        //     _view.Rigidbody.drag = _config.Drag;
        //     _view.Rigidbody.velocity = _view.transform.forward * _config.InitialSpeed;
        // }

        public ProjectileType GetProjectileType()
        {
            return _config.ProjectileType;
        }
    }
}