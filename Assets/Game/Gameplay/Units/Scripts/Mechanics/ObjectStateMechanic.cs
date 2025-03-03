using System;
using FPSShooter.Modules.Gameplay.Impact;
using FPSShooter.Modules.Units;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Units.UnitLogic
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class ObjectStateMechanic : IUnitMechanic, IInitializable
    {
        public event Action<ImpactData> OnObjectStateAffected;
        public event Action OnObjectDestroyed;
        public ObjectState ObjectState => _objectState;

        public int CurrentHealth
        {
            get => _objectState.CurrentHealth;
            set
            {
                _objectState.CurrentHealth = value;
                CheckForDeath();
            }
        }
        
        public bool IsDead => _objectState.IsDead;

        private readonly ObjectState _objectState;

        public ObjectStateMechanic(ObjectState objectState)
        {
            _objectState = objectState;
        }
        
        public void Initialize()
        {
            _objectState.Reset();
        }

        public void Affect(ImpactData data)
        {
            if (_objectState.IsInvincible) return;
            if (_objectState.IsDead) return;
            _objectState.CurrentHealth += data.HealthDelta;
            OnObjectStateAffected?.Invoke(data);
            
            CheckForDeath();
        }

        private void CheckForDeath()
        {
            if (_objectState.CurrentHealth <= _objectState.MinHealth)
            {
                OnObjectDestroyed?.Invoke();
                _objectState.IsDead = true;
            }
        }
        
    }
}