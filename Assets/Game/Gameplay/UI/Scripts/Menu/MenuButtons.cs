using System;
using UnityEngine;
using UnityEngine.UI;

namespace FPSShooter.Game.Gameplay.UI
{
    // ReSharper disable once ClassNeverInstantiated.Global
    [Serializable]
    public sealed class MenuButtons
    {
        [SerializeField] private Button _saveBtn;
        [SerializeField] private Button _loadBtn;
        [SerializeField] private Button _exitBtn;
        [SerializeField] private Button _toggleBtn;
        public Button.ButtonClickedEvent OnSaveClicked => _saveBtn.onClick;
        public Button.ButtonClickedEvent OnLoadClicked => _loadBtn.onClick;
        public Button.ButtonClickedEvent OnExitClicked => _exitBtn.onClick;
        public Button.ButtonClickedEvent OnToggleClicked => _toggleBtn.onClick;
    }
}