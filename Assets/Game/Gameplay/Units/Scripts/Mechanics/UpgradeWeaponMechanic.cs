using System;
using FPSShooter.Core.Utils;
using FPSShooter.Game.Gameplay.Units.UnitLogic;
using FPSShooter.Modules.CurrencyStorage;
using FPSShooter.Modules.FPSCamera;
using FPSShooter.Modules.Meta.Upgrades.Presenters;
using FPSShooter.Modules.Meta.Upgrades.UI;
using FPSShooter.Modules.Units;

namespace FPSShooter.Game.Gameplay.Units
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class UpgradeWeaponMechanic : IUnitMechanic
    {
        public event Action OnStartUpgrading;
        public event Action OnStopUpgrading;
        
        private readonly WeaponArsenalMechanic _weaponArsenalMechanic;
        private readonly FPSCameraController _fpsCamera;
        private readonly UpgradePanelList _upgradePanelList;
        private readonly CursorToggler _cursorToggler;
        private readonly ICurrencyStorage _currencyStorage;

        private bool _isUpgrading;

        public UpgradeWeaponMechanic(WeaponArsenalMechanic weaponArsenalMechanic,
            FPSCameraController fpsCamera,
            UpgradePanelList upgradePanelList,
            CursorToggler cursorToggler,
            ICurrencyStorage currencyStorage)
        {
            _weaponArsenalMechanic = weaponArsenalMechanic;
            _fpsCamera = fpsCamera;
            _upgradePanelList = upgradePanelList;
            _cursorToggler = cursorToggler;
            _currencyStorage = currencyStorage;
            _isUpgrading = false;
        }

        public void ToggleUpgradeState()
        {
            if (_isUpgrading)
            {
                _upgradePanelList.Hide();
                _isUpgrading = false;
                
                _weaponArsenalMechanic.StopUpgrading();
                _weaponArsenalMechanic.EnableUseWeapon();
                _fpsCamera.Enable();
                _cursorToggler.HideCursor();
                
                OnStopUpgrading?.Invoke();
            }
            else
            {
                if (!TryShowUpgradePanel()) return;
                
                _weaponArsenalMechanic.StartUpgrading();
                _weaponArsenalMechanic.DisableUseWeapon();
                _fpsCamera.Disable();
                _isUpgrading = true;
                _cursorToggler.ShowCursor();
                
                OnStartUpgrading?.Invoke();
            }
        }

        private bool TryShowUpgradePanel()
        {
            var currentWeapon = _weaponArsenalMechanic.GetCurrentWeapon();
            if (currentWeapon == null) return false;
            var availableUpgrades = currentWeapon.GetAvailableUpgrades();
            var upgradeListPresenter = new UpgradeListPresenter(availableUpgrades, _currencyStorage);
            _upgradePanelList.Show(upgradeListPresenter);
            return true;
        }
    }
}