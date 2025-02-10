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
        
        private Player _player;
        private GameLoopManager _gameLoopManager;
        private IObjectResolver _objectResolver;
        
        //TODO: player config
        [Inject]
        private void Configure(GameLoopManager gameLoopManager, IObjectResolver objectResolver)
        {
            _gameLoopManager = gameLoopManager;
            _objectResolver = objectResolver;
        }

        private void Start()
        {
             CreatePlayer();
        }

        private void CreatePlayer()
        {
            var playerGameObject = Instantiate(_playerPrefab, _playerContainer.position, _playerContainer.rotation, _playerContainer);
            _player = playerGameObject.GetComponent<Player>();
            _gameLoopManager.AddListener(_player);
            
            PlayerCreated?.Invoke();
        }

        public Player GetPlayer()
        {
            return _player;
        }
    }
}
