using FPSShooter.Core.Utils;
using FPSShooter.Game.Core.SaveLoaders;
using FPSShooter.Modules.Core.GameLoop;
using HomeworkSaveLoad.SaveSystem;
using UnityEditor;
using UnityEngine;

namespace FPSShooter.Game.Gameplay.UI
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class MenuPresenter : IMenuPresenter
    {
        private readonly MenuView _view;
        private readonly IGameLoopManager _gameLoopManager;
        private readonly CursorToggler _cursorToggler;
        private readonly ISaveLoadPipeline _saveLoadPipeline;
        
        public MenuPresenter(MenuView view, IGameLoopManager gameLoopManager, CursorToggler cursorToggler, ISaveLoadPipeline saveLoadPipeline)
        {
            _view = view;
            _gameLoopManager = gameLoopManager;
            _cursorToggler = cursorToggler;
            _saveLoadPipeline = saveLoadPipeline;
            _view.gameObject.SetActive(false);
        }
        
        public void SaveGame()
        {
            _saveLoadPipeline.Save();
            Toggle();
        }

        public void LoadGame()
        {
            _saveLoadPipeline.Load();
            Toggle();
        }

        public void ExitGame()
        {
            #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
            #endif 
            Application.Quit();
        }

        public void Toggle()
        {
            _view.gameObject.SetActive(!_view.gameObject.activeSelf);
            if (_view.gameObject.activeSelf)
            {
                _gameLoopManager.PauseGame();
                _cursorToggler.ShowCursor();
            }
            else
            {
                _gameLoopManager.ResumeGame();
                _cursorToggler.HideCursor();
            }
        }
    }
}