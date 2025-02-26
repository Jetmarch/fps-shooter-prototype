using System.Collections.Generic;

namespace FPSShooter.Modules.Units
{
    public interface IUnitPresenter
    {
        T GetLogic<T>() where T : IUnitMechanic;
        void AddLogic(IUnitMechanic mechanic);
        List<IUnitMechanic> UnitMechanics { get; }
    }
}