using UnityEngine;

namespace FPSShooter.Game.Gameplay.UI
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class MenuPresenter : IMenuPresenter
    {
        private readonly MenuView _view;
        
        public MenuPresenter(MenuView view)
        {
            _view = view;
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
        }
    }
}