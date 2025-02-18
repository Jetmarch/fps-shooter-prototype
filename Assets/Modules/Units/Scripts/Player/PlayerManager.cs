using UnityEngine;

namespace FPSShooter.Modules.Units
{
    public sealed class PlayerManager : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Transform _playerContainer;
        
        private UnitView _unitView;
        
        private void Start()
        {
             CreatePlayer();
        }

        private void CreatePlayer()
        {
            var playerGameObject = Instantiate(_playerPrefab, _playerContainer.position, _playerContainer.rotation, _playerContainer);
            _unitView = playerGameObject.GetComponent<UnitView>();
        }

        public UnitView GetPlayer()
        {
            return _unitView;
        }
    }
}
