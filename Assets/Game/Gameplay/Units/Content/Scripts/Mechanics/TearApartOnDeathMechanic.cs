using FPSShooter.Core.Managers;
using FPSShooter.Modules.Units;

namespace FPSShooter.Game.Gameplay.Units.UnitLogic
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class TearApartOnDeathMechanic : IUnitMechanics
    {
        private readonly DieMechanic _dieMechanic;
        private readonly IParticlesManager _particlesManager;
        private readonly ParticleType _deathParticles = ParticleType.TearApartDeath;
        private readonly UnitView _view;

        public TearApartOnDeathMechanic(DieMechanic dieMechanic, IParticlesManager particlesManager, UnitView view)
        {
            _dieMechanic = dieMechanic;
            _particlesManager = particlesManager;
            _view = view;
        }

        public void TearApartDeath()
        {
            _particlesManager?.SpawnParticles(_deathParticles, _view.transform.position, _view.transform.rotation);
            _dieMechanic.Die();
        }
    }
}