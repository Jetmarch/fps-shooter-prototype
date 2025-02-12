using System.Collections;
using UnityEngine;

namespace FPSShooter.Code.Gameplay.Weapons
{
    //TODO: remove MonoBehaviour
    public sealed class ProceduralRecoilAnimationController : MonoBehaviour
    {
        [SerializeField] private float _recoilSpeed = 0.1f;
        [SerializeField] private float _recoilDuration = 0.15f;
        [SerializeField] private float _returnSpeed = 10f;
        
        [SerializeField] private AnimationCurve _recoilCurve;

        private Vector3 _originalPosition;
        private Quaternion _originalRotation;
        private Vector3 _recoilOffset;
        private Quaternion _recoilRotation;
        private bool _isRecoiling;
        
        private float _recoilTime;
        
        private void Start()
        {
            _originalPosition = transform.localPosition;
            _originalRotation = transform.localRotation;
        }

        private void Update()
        {
            if (_isRecoiling)
            {
                var recoilAmount = _recoilCurve.Evaluate(_recoilTime);
                _recoilOffset = Vector3.Lerp(_recoilOffset, Vector3.back * recoilAmount, _recoilSpeed * Time.deltaTime);
                _recoilRotation = Quaternion.Euler(new Vector3(-recoilAmount, 0f, 0f));
                _recoilTime += Time.deltaTime;
            }
            else
            {
                _recoilOffset = Vector3.Lerp(_recoilOffset, Vector3.zero, Time.deltaTime * _returnSpeed);
                _recoilRotation = Quaternion.Slerp(_recoilRotation, _originalRotation, Time.deltaTime * _returnSpeed);
            }
            
            transform.localPosition = _originalPosition + _recoilOffset;
            transform.localRotation = _originalRotation * _recoilRotation;
        }

        public void Recoil()
        {
            StartCoroutine(RecoilAnimation());
        }

        private IEnumerator RecoilAnimation()
        {
            _isRecoiling = true;
            _recoilTime = 0f;
            yield return new WaitForSeconds(_recoilDuration);
            _isRecoiling = false;
        }
    }
}