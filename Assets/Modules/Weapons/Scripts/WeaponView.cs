using UnityEngine;
using VContainer;

namespace FPSShooter.Modules.Gameplay.Weapons
{
    public sealed class WeaponView : MonoBehaviour, IWeapon
    {
        public Vector3 Position { get => transform.position; set => transform.position = value; }
        public Quaternion Rotation { get => transform.rotation; set => transform.rotation = value; }
        
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private ProceduralRecoilAnimationController _proceduralRecoil;
        
        //TODO: use particle manager
        [SerializeField] private ParticleSystem _shotEffect;
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

        public void RequestStartAutomaticShoot()
        {
            _presenter.StartShootAutomatic();
        }

        public void RequestEndAutomaticShoot()
        {
            _presenter.EndShootAutomatic();
        }
        
        public void RequestReload()
        {
            _presenter.Reload();
        }

        public void Recoil()
        {
            _proceduralRecoil.Recoil();
        }

        public void PlayShotVFX()
        {
            _shotEffect.Play();
        }
        
        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
        }

        public void PullOut()
        {
            _presenter.PullOut();
        }

        public void PutAway()
        {
            _presenter.PutAway();
        }
    }
}
