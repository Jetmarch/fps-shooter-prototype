using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

namespace FPSShooter.Gameplay.Utils
{
    [Serializable]
    public sealed class GameObjectPool : IInitializable
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Transform _parent;
        [SerializeField] private int _poolSize;
        
        private Queue<GameObject> _pool;

        public GameObjectPool(GameObject prefab, Transform parent, int poolSize)
        {
            _prefab = prefab;
            _parent = parent;
            _poolSize = poolSize;
            _pool = new Queue<GameObject>();
        }
        
        public void Initialize()
        {
            for (int i = 0; i < _poolSize; i++)
            {
                var gameObject = UnityEngine.Object.Instantiate(_prefab, _parent);
                gameObject.SetActive(false);
                _pool.Enqueue(gameObject);
            }
        }

        public GameObject GetObject()
        {
            if (_pool.Count > 0)
            {
                var gameObject = _pool.Dequeue();
                gameObject.SetActive(true);
                return gameObject;
            }
            
            var newGmeObject = UnityEngine.Object.Instantiate(_prefab, _parent);
            return newGmeObject;
        }

        public void ReturnObject(GameObject gameObject)
        {
            gameObject.SetActive(false);
            _pool.Enqueue(gameObject);
        }
    }
}