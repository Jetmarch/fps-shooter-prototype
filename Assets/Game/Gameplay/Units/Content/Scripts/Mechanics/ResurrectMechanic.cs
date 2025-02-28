using FPSShooter.Core.Managers;
using FPSShooter.Modules.Units;
using UnityEngine;

namespace FPSShooter.Game.Gameplay.Units.UnitLogic
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class ResurrectMechanic : IUnitMechanic
    {
        private readonly ObjectStateMechanic _objectStateMechanic;
        private readonly Animator _animator;
        private readonly Collider _collider;
        private readonly UnitView _view;
        private readonly IParticlesManager _particlesManager;
        private readonly SoundPlayer _soundPlayer;
        private readonly string _resurrectParticles = "resurrection";
        private readonly string _resurrectSound = "dummyResurrect";

        public ResurrectMechanic(ObjectStateMechanic objectStateMechanic, Animator animator, Collider collider, UnitView view, IParticlesManager particlesManager, SoundPlayer soundPlayer)
        {
            _objectStateMechanic = objectStateMechanic;
            _animator = animator;
            _collider = collider;
            _view = view;
            _particlesManager = particlesManager;
            _soundPlayer = soundPlayer;
        }

        public void Resurrect()
        {
            _objectStateMechanic.Initialize();
            _animator.Rebind();
            _animator.Update(0f);
            _collider.enabled = true;
            _particlesManager?.SpawnParticles(_resurrectParticles, _view.transform.position, _view.transform.rotation);
            _soundPlayer.TryPlaySound(_resurrectSound);
        }
    }
}