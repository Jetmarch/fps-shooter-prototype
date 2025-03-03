using System;
using System.Collections.Generic;
using System.Linq;
using FPSShooter.Modules.Units;

namespace FPSShooter.Game.Gameplay.Units.Player
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class UnitPresenter : IUnitPresenter
    {
        public List<IUnitMechanic> UnitMechanics => _unitMechanics;
        
        private readonly List<IUnitMechanic> _unitMechanics;

        public UnitPresenter(IEnumerable<IUnitMechanic> logic)
        {
            _unitMechanics = logic.ToList();
        }

        public T GetMechanic<T>() where T : IUnitMechanic
        {
            //TODO: change list to dictionary
            foreach (var unitMechanic in _unitMechanics)
            {
                if(unitMechanic is T) return (T)unitMechanic;
            }

            return default(T);
        }

        public void AddLogic(IUnitMechanic mechanic)
        {
            throw new System.NotImplementedException();
        }
    }
}