using System;
using System.Collections.Generic;
using System.Linq;
using FPSShooter.Modules.Units;

namespace FPSShooter.Game.Gameplay.Units.Player
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class UnitPresenter : IUnitPresenter
    {
        public List<IUnitMechanics> UnitMechanics => _unitMechanics;
        
        private List<IUnitMechanics> _unitMechanics;

        public UnitPresenter(IEnumerable<IUnitMechanics> logic)
        {
            _unitMechanics = logic.ToList();
        }

        public T GetLogic<T>() where T : IUnitMechanics
        {
            //TODO: change list to dictionary
            foreach (var unitMechanic in _unitMechanics)
            {
                if(unitMechanic is T) return (T)unitMechanic;
            }

            return default(T);
        }

        public void AddLogic(IUnitMechanics mechanics)
        {
            throw new System.NotImplementedException();
        }
    }
}