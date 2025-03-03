using FPSShooter.Core.Managers;
using FPSShooter.Modules.Units;

namespace FPSShooter.Game.Gameplay.Units.UnitLogic
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class TearApartOnDeathMechanic : IUnitMechanic
    {
        private readonly DeathMechanic _deathMechanic;
        private readonly IParticlesManager _particlesManager;
        private readonly UnitView _view;
        private readonly SoundPlayer _soundPlayer;
        private readonly string _deathParticles = "bigBoneExplosion";
        private readonly string _tearApartDeathSound;

        public TearApartOnDeathMechanic(DeathMechanic deathMechanic, IParticlesManager particlesManager, UnitView view, SoundPlayer soundPlayer)
        {
            _deathMechanic = deathMechanic;
            _particlesManager = particlesManager;
            _view = view;
            _tearApartDeathSound = "dummyTearApartDeath";
            _soundPlayer = soundPlayer;
        }

        public void Death()
        {
            _particlesManager?.SpawnParticles(_deathParticles, _view.transform.position, _view.transform.rotation);
            _soundPlayer.TryPlaySound(_tearApartDeathSound);
            _deathMechanic.Die();
        }
    }
}