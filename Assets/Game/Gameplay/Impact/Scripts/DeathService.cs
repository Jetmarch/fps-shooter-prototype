using System;
using System.Timers;
using FPSShooter.Modules.Core.GameLoop;
using FPSShooter.Modules.Gameplay.Impact;
using UnityEngine;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Impact
{
    // ReSharper disable once ClassNeverInstantiated.Global
    //TODO: global service
    public class DeathService : IInitializable, IDisposable, IUpdateListener
    {
        public event Action OnTearApart; 
        public event Action OnSimpleDeath;
        
        private readonly ObjectState _objectState;
        private readonly float _percentOfMaxHealthToTearApart = 0.5f;
        private readonly float _resetAmountRecentDamageDelay = 1f;
        private float _currentResetDelay;
        private float _amountOfRecentDamage;

        public DeathService(ObjectState objectState)
        {
            _objectState = objectState;
        }

        public void Initialize()
        {
            _objectState.OnObjectDestroyed += Death;
            _objectState.OnHealthChanged += AccumulateDamage;
        }

        public void Dispose()
        {
            _objectState.OnHealthChanged -= AccumulateDamage;
            _objectState.OnObjectDestroyed -= Death;
        }

        private void Death()
        {
            if (_amountOfRecentDamage > _objectState.MaxHealth * _percentOfMaxHealthToTearApart)
            {
                OnTearApart?.Invoke();
            }
            else
            {
                OnSimpleDeath?.Invoke();
            }
        }

        private void AccumulateDamage(ImpactData impactData)
        {
            _amountOfRecentDamage += Mathf.Abs(impactData.HealthDelta);
        }
        
        private void ResetRecentDamage()
        {
            _amountOfRecentDamage = 0;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_amountOfRecentDamage <= 0f) return; 
            _currentResetDelay += deltaTime;
            if (_currentResetDelay >= _resetAmountRecentDamageDelay)
            {
                _currentResetDelay = 0f;
                ResetRecentDamage();
            }
        }
    }
}