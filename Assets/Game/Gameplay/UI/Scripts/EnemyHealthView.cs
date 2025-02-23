using System;
using FPSShooter.Modules.Units;
using UnityEngine;
using UnityEngine.UI;

namespace FPSShooter.Game.Gameplay.UI
{
    public class EnemyHealthView : MonoBehaviour
    {
        [SerializeField] private Slider _healthSlider;
        [SerializeField] private LayerMask _raycastLayerMask;
        [SerializeField] private UnitView _currentTarget;
        [SerializeField] private float _targetFollowTime = 2f;
        [SerializeField] private Vector3 _offsetScreenBorder;
        [SerializeField] private Vector3 _offsetOnTarget;
        private Camera _camera;
        
        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                float rayDistance = Mathf.Infinity;
                Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

                if (Physics.Raycast(ray, out RaycastHit hit, rayDistance, _raycastLayerMask))
                {
                    Debug.Log(hit.collider.gameObject.name);

                    if (hit.collider.gameObject.TryGetComponent<UnitView>(out var unit))
                    {
                        _currentTarget = unit;
                    }
                }
            }

            if (_currentTarget != null)
            {
                FollowTarget();
            }
        }

        private void FollowTarget()
        {
            var healthBarPosition = _currentTarget.transform.position + _offsetOnTarget;
            var healthBarScreenPosition = _camera.WorldToScreenPoint(healthBarPosition);
            if (IsTargetOnScreen(healthBarScreenPosition))
            {
                _healthSlider.transform.position = healthBarScreenPosition;
                _healthSlider.gameObject.SetActive(true);
                var targetState = _currentTarget.GetObjectStateData();
                var healthInPercent = (float)targetState.CurrentHealth / (float)targetState.MaxHealth * 100f;
                _healthSlider.value = healthInPercent;
            }
            else
            {
                _healthSlider.gameObject.SetActive(false);
                _healthSlider.transform.position = ClampToScreenPosition(healthBarScreenPosition);
            }
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
