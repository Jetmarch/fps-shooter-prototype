using UnityEngine;
using VContainer;

namespace FPSShooter.Gameplay.Weapons
{
    public sealed class WeaponView : MonoBehaviour
    {
        [SerializeField] private WeaponConfig _weaponConfig;
        [SerializeField] private Transform _shootPoint;

        [SerializeField] private Weapon _weapon;

        private IObjectResolver _objectResolver;
        
        [Inject]
        private void Configure(IObjectResolver resolver)
        {
            _objectResolver = resolver;
        }

        private void Start()
        {
            _weapon = _weaponConfig.GetClone(_objectResolver);
        }

        public void Shoot()
        {
            _weapon.TryShoot(_shootPoint);
        }
        
        public void Reload()
        {
            _weapon.TryReload();
        }
    }
}
