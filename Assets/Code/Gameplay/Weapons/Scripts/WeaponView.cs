using FPSShooter.Code.Gameplay.Weapons;
using UnityEngine;
using VContainer;

namespace FPSShooter.Gameplay.Weapons
{
    public sealed class WeaponView : MonoBehaviour, IWeapon
    {
        public Vector3 Position { get => transform.position; set => transform.position = value; }
        public Quaternion Rotation { get => transform.rotation; set => transform.rotation = value; }
        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
        }

        [SerializeField] private Transform _shootPoint;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private ProceduralRecoilAnimationController _proceduralRecoil;
        public Transform ShootPoint => _shootPoint;
        
        private IWeaponPresenter _presenter;

        [Inject]
        public void Configure(IWeaponPresenter presenter)
        {
            _presenter = presenter;
        }

        public void RequestShoot()
        {
            _presenter.Shoot();
        }
        
        public void RequestReload()
        {
            _presenter.Reload();
        }

        public void Recoil()
        {
            _proceduralRecoil.Recoil();
        }
    }
}
