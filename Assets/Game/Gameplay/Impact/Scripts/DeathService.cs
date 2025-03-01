using System;
using System.Timers;
using FPSShooter.Modules.Gameplay.Impact;
using UnityEngine;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Impact
{
    // ReSharper disable once ClassNeverInstantiated.Global
    //TODO: global service
    public class DeathService : IInitializable, IDisposable
    {
        public event Action OnTearApart; 
        public event Action OnSimpleDeath;
        
        private readonly ObjectState _objectState;
        private readonly float _resetToZeroDelayMs = 1000f;
        private readonly float _percentOfMaxHealthToTearApart = 0.5f;
        private readonly Timer _resetRecentDamageTimer;
        private float _amountOfRecentDamage;
        

        public DeathService(ObjectState objectState)
        {
            _objectState = objectState;
            _resetRecentDamageTimer = new Timer(_resetToZeroDelayMs);
            _resetRecentDamageTimer.Elapsed += ResetRecentDamage;
            _resetRecentDamageTimer.AutoReset = false;
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
            _resetRecentDamageTimer.Stop();
            _resetRecentDamageTimer.Start();
        }
        
        private void ResetRecentDamage(object sender, ElapsedEventArgs e)
        {
            _amountOfRecentDamage = 0;
            Debug.Log("Reset recent damage");
        }
    }
}