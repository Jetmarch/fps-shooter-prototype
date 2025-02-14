using System;
using FPSShooter.Core.Managers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace FPSShooter.Gameplay.Units
{
    public sealed class PlayerManager : MonoBehaviour
    {
        public event Action PlayerCreated;
        public event Action PlayerDestroyed;
        
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Transform _playerContainer;
        
        private PlayerView _playerView;
        private GameLoopManager _gameLoopManager;
        
        //TODO: player config
        [Inject]
        private void Configure(GameLoopManager gameLoopManager)
        {
            _gameLoopManager = gameLoopManager;
        }

        private void Start()
        {
             CreatePlayer();
        }

        private void CreatePlayer()
        {
            var playerGameObject = Instantiate(_playerPrefab, _playerContainer.position, _playerContainer.rotation, _playerContainer);
            _playerView = playerGameObject.GetComponent<PlayerView>();
            _gameLoopManager.AddListener(_playerView);
            
            PlayerCreated?.Invoke();
        }

        public PlayerView GetPlayer()
        {
            return _playerView;
        }
    }
}
