using FPSShooter.Modules.Meta.Upgrades.Presenters;
using TMPro;
using UnityEngine;

namespace FPSShooter.Modules.Meta.Upgrades.UI
{
    public sealed class UpgradePanel : MonoBehaviour
    {
        [SerializeField] private GameObject _container;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _valueText;
        [SerializeField] private TextMeshProUGUI _levelText;
        
        [SerializeField] private UpgradeButton _upgradeButton;

        private IUpgradePresenter _presenter;
        
        public void Configure(IUpgradePresenter presenter)
        {
            _presenter = presenter;
            _upgradeButton.Configure(presenter.GetUpgradeButtonPresenter());
            Show();
        }

        public void Show()
        {
            _container.SetActive(true);
            UpdatePanelState();
            _upgradeButton.Show();
            _upgradeButton.OnLevelUp += UpgradeButtonOnLevelUp;
        }
        public void Hide()
        {
            _upgradeButton.OnLevelUp += UpgradeButtonOnLevelUp;
            _upgradeButton.Hide();
            _container.SetActive(false);
        }

        private void UpdatePanelState()
        {
            _nameText.text = _presenter.Name;
            _valueText.text = _presenter.Value;
            _levelText.text = _presenter.Level;
        }
        
        private void UpgradeButtonOnLevelUp()
        {
            UpdatePanelState();
        }
    }
}
