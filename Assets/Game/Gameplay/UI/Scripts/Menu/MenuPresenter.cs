using FPSShooter.Core.Utils;
using FPSShooter.Modules.Core.GameLoop;
using UnityEngine;

namespace FPSShooter.Game.Gameplay.UI
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class MenuPresenter : IMenuPresenter
    {
        private readonly MenuView _view;
        private readonly IGameLoopManager _gameLoopManager;
        private readonly CursorToggler _cursorToggler;
        
        public MenuPresenter(MenuView view, IGameLoopManager gameLoopManager, CursorToggler cursorToggler)
        {
            _view = view;
            _gameLoopManager = gameLoopManager;
            _cursorToggler = cursorToggler;
            _view.gameObject.SetActive(false);
        }
        
        public void SaveGame()
        {
            Debug.LogError("Save game feature is not implemented.");
        }

        public void LoadGame()
        {
            Debug.LogError("Load game feature is not implemented.");
        }

        public void ExitGame()
        {
            Debug.LogError("Exit game feature is not implemented.");
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