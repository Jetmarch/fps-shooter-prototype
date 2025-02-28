using System.Collections.Generic;

namespace FPSShooter.Modules.Units
{
    public interface IUnitPresenter
    {
        T GetMechanic<T>() where T : IUnitMechanic;
        void AddLogic(IUnitMechanic mechanic);
        List<IUnitMechanic> UnitMechanics { get; }
    }
}