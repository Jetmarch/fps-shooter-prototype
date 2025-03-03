using FPSShooter.Modules.Gameplay.Projectiles;
using FPSShooter.Modules.Units;

namespace FPSShooter.Game.Gameplay.Projectiles
{
    
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class ProjectileMechanic : IUnitMechanic
    {
        public ProjectileConfig Config => _config;
        public ProjectileType ProjectileType => _config.ProjectileType;
        private readonly ProjectileConfig _config;

        public ProjectileMechanic(ProjectileConfig config)
        {
            _config = config;
        }
    }
}