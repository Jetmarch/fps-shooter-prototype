

namespace FPSShooter.Modules.Units
{
    public interface IUnitPresenter
    {
        T GetMechanic<T>() where T : IUnitMechanic;
    }
}