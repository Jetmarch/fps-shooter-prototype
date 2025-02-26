using FPSShooter.Modules.Units;
using UnityEngine;

namespace FPSShooter.Game.Gameplay.Units.UnitLogic
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class DieMechanic : IUnitMechanic
    {
        private readonly Animator _animator;
        private readonly int _deathTrigger = Animator.StringToHash("Death");
        private readonly Collider _collider;

        public DieMechanic(Animator animator, Collider collider)
        {
            _animator = animator;
            _collider = collider;
        }

        public void Die()
        {
            _collider.enabled = false;
            _animator.SetTrigger(_deathTrigger);
        }
    }

}