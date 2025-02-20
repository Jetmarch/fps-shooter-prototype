using System.Collections.Generic;
using Helpers;
using Newtonsoft.Json;
// ReSharper disable ClassNeverInstantiated.Global

namespace HomeworkSaveLoad.SaveSystem
{
    public sealed class GameRepository : IGameRepository
    {
        private const string SaveFileName = "data.sav";
        
        private Dictionary<string, string> _gameData = new();

        public bool TryGetData<T>(out T data)
        {
            var key = typeof(T).ToString();
            
            if (!_gameData.TryGetValue(key, out var json))
            {
                data = default;
                return false;
            }
            
            data = JsonConvert.DeserializeObject<T>(json);
            return true;
        }

        public void SetData<T>(T data)
        {
            var key = typeof(T).ToString();
            var json = JsonUseCases.SerializeObject(data);
            _gameData[key] = json;
        }

        public void LoadState()
        {
            var encryptedJson = FileHelper.ReadAllFromFile(SaveFileName);
            if (encryptedJson == string.Empty) return;
            
            var json = StringEncryptHelper.Decrypt(encryptedJson);
            _gameData = JsonUseCases.DeserializeObject<Dictionary<string, string>>(json);
        }

        public void SaveState()
        {
            var json = JsonUseCases.SerializeObject(_gameData);
            var encryptedJson = StringEncryptHelper.Encrypt(json);
            FileHelper.WriteToFile(SaveFileName, encryptedJson);
        }
    }
}