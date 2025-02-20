using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace HomeworkSaveLoad.SaveSystem
{
    public sealed class SaveLoadManager : MonoBehaviour
    {
        private IEnumerable<ISaveLoader> _saveLoaders;
        private IGameContext _gameContext;
        private IGameRepository _gameRepository;
        
        [Inject]
        private void Construct(IEnumerable<ISaveLoader> saveLoaders, IGameContext gameContext, IGameRepository gameRepository)
        {
            _saveLoaders = saveLoaders;
            _gameContext = gameContext;
            _gameRepository = gameRepository;
        }
        
        [Button]
        public void Save()
        {
            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.SaveGame(_gameContext, _gameRepository);
            }
            
            _gameRepository.SaveState();
        }

        [Button]
        public void Load()
        {
            _gameRepository.LoadState();
            
            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.LoadGame(_gameContext, _gameRepository);
            }
        }
    }
}