using System.Collections.Generic;

namespace FPSShooter.Modules.Units
{
    public interface IUnitPresenter
    {
        T GetLogic<T>() where T : IUnitMechanics;
        void AddLogic(IUnitMechanics mechanics);
        List<IUnitMechanics> UnitMechanics { get; }
    }
}