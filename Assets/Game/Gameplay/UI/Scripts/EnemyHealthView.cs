using FPSShooter.Modules.Gameplay.Projectiles;
using FPSShooter.Modules.Units;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace FPSShooter.Game.Gameplay.UI
{
    public sealed class EnemyHealthView : MonoBehaviour
    {
        [SerializeField] private Slider _healthSlider;
        [SerializeField] private LayerMask _raycastLayerMask;
        [SerializeField] private UnitView _currentTarget;
        [SerializeField] private float _targetFollowTime = 2f;
        [SerializeField] private Vector3 _offsetScreenBorder;
        [SerializeField] private Vector3 _offsetOnTarget;
        private Camera _camera;
        
        private IProjectileManager _projectileManager;

        [Inject]
        private void Configure(IProjectileManager projectileManager)
        {
            _projectileManager = projectileManager;
        }

        private void Start()
        {
            _camera = Camera.main;
            _projectileManager.OnProjectileHitObject += OnProjectileHitObject;
        }

        private void OnProjectileHitObject(GameObject obj)
        {
            if (obj.TryGetComponent<UnitView>(out var unit))
            {
                _currentTarget = unit;
            }
        }

        private void Update()
        {
            if (_currentTarget != null)
            {
                FollowTarget();
            }
            else
            {
                HideFromScreen();
            }
        }

        private void FollowTarget()
        {
            var healthBarPosition = _currentTarget.transform.position + _offsetOnTarget;
            var healthBarScreenPosition = _camera.WorldToScreenPoint(healthBarPosition);
            _healthSlider.gameObject.SetActive(true);
            var targetState = _currentTarget.GetObjectStateData();
            var healthInPercent = (float)targetState.CurrentHealth / (float)targetState.MaxHealth * 100f;
            _healthSlider.value = healthInPercent;
            
            if (IsTargetOnScreen(healthBarScreenPosition))
            {
                _healthSlider.transform.position = healthBarScreenPosition;
            }
            else
            {
                _healthSlider.transform.position = ClampToScreenPosition(healthBarScreenPosition);
            }
        }

        private void HideFromScreen()
        {
            _healthSlider.gameObject.SetActive(false);
        }
        
        private bool IsTargetOnScreen(Vector3 targetPosition)
        {
            if (targetPosition.x > Screen.width || targetPosition.x < 0) return false;
            if (targetPosition.y > Screen.height || targetPosition.y < 0) return false;
            return true;
        }
        
        private Vector3 ClampToScreenPosition(Vector3 position)
        {
            float x = Mathf.Clamp(position.x, _offsetScreenBorder.x, Screen.width - _offsetScreenBorder.x);
            float y = Mathf.Clamp(position.y, _offsetScreenBorder.y, Screen.height - _offsetScreenBorder.y);
            return new Vector3(x, y, position.z);
        }
    }
}
