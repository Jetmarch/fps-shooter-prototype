using System;
using FPSShooter.Modules.Gameplay.Projectiles;
using FPSShooter.Modules.Units;
using UnityEngine;

namespace FPSShooter.Game.Gameplay.Projectiles
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class DestroyMechanic : IUnitMechanic
    {
        public event Action<GameObject> NotifyUnitDestroyed;
        
        private readonly UnitView _view;
        
        public DestroyMechanic(UnitView view)
        {
            _view = view;
        }
        
        public void Destroy()
        {
            NotifyUnitDestroyed?.Invoke(_view.gameObject);
        }
    }
}