using System;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.UI
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class MenuController : IInitializable, IDisposable
    {
        private readonly MenuView _menuView;
        private readonly MenuButtons _menuButtons;

        public MenuController(MenuView menuView, MenuButtons menuButtons)
        {
            _menuView = menuView;
            _menuButtons = menuButtons;
        }

        public void Initialize()
        {
            _menuButtons.OnSaveClicked.AddListener(_menuView.SaveGame);
            _menuButtons.OnLoadClicked.AddListener(_menuView.LoadGame);
            _menuButtons.OnExitClicked.AddListener(_menuView.ExitGame);
            _menuButtons.OnToggleClicked.AddListener(_menuView.Toggle);
            
        }

        public void Dispose()
        {
            _menuButtons.OnSaveClicked.RemoveListener(_menuView.SaveGame);
            _menuButtons.OnLoadClicked.RemoveListener(_menuView.LoadGame);
            _menuButtons.OnExitClicked.RemoveListener(_menuView.ExitGame);
            _menuButtons.OnToggleClicked.RemoveListener(_menuView.Toggle);
        }
    }
}