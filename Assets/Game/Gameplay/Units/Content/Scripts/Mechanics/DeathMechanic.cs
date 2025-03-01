using FPSShooter.Modules.Units;
using UnityEngine;

namespace FPSShooter.Game.Gameplay.Units.UnitLogic
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class DeathMechanic : IUnitMechanic
    {
        private readonly Animator _animator;
        private readonly int _deathAnimationTrigger = Animator.StringToHash("Death");
        //private readonly AnimationLayer _animationPlayer;
        private readonly Collider _collider;
        private readonly SoundPlayer _soundPlayer;
        private readonly string _deathSound;

        public DeathMechanic(Animator animator, Collider collider, SoundPlayer soundPlayer)
        {
            _animator = animator;
            _deathSound = "dummyDeath";
            _collider = collider;
            _soundPlayer = soundPlayer;
        }

        public void Die()
        {
            _collider.enabled = false;
            _animator.SetTrigger(_deathAnimationTrigger);
            //_animationPlayer.PlayDeathAnimation();
            _soundPlayer.TryPlaySound(_deathSound);
        }
    }
}