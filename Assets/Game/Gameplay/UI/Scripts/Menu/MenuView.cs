using UnityEngine;
using VContainer;

namespace FPSShooter.Game.Gameplay.UI
{
    public sealed class MenuView : MonoBehaviour
    {
        private IMenuPresenter _presenter;
        
        [Inject]
        private void Configure(IMenuPresenter presenter)
        {
            _presenter = presenter;
        }

        public void SaveGame()
        {
            _presenter.SaveGame();
        }

        public void LoadGame()
        {
            _presenter.LoadGame();
        }

        public void ExitGame()
        {
            _presenter.ExitGame();
        }

        public void Toggle()
        {
            _presenter.Toggle();
        }
    }
}
