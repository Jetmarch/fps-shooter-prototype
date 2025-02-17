using System;
using FPSShooter.Modules.Core.GameLoop;
using UnityEngine;
using VContainer;

namespace FPSShooter.Modules.Units
{
    public sealed class PlayerManager : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Transform _playerContainer;
        
        private PlayerView _playerView;
        private IGameLoopManager _gameLoopManager;
        
        [Inject]
        private void Configure(IGameLoopManager gameLoopManager)
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
        }
    }
}
