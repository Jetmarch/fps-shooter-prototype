using UnityEngine;
using VContainer;

namespace FPSShooter.Gameplay.Weapons
{
    public sealed class WeaponView : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private float _rotationSpeed;
        public Transform ShootPoint => _shootPoint;
        
        private IWeaponPresenter _presenter;

        [Inject]
        public void Configure(IWeaponPresenter presenter)
        {
            _presenter = presenter;
        }

        public void Shoot()
        {
            _presenter.Shoot();
        }
        
        public void Reload()
        {
            _presenter.Reload();
        }
    }
}
