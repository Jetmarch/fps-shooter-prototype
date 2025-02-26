
using UnityEngine;
using VContainer;

namespace FPSShooter.Modules.Units
{
    public sealed class UnitView : MonoBehaviour
    {
        private IUnitPresenter _presenter;

        [Inject]
        private void Construct(IUnitPresenter presenter)
        {
            _presenter = presenter;
        }
        
        public T GetMechanic<T>() where T : IUnitMechanic
        {
            return _presenter.GetLogic<T>();
        }
    }
}
