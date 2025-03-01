using FPSShooter.Modules.Meta.Upgrades.UI;
using FPSShooter.Modules.Units;
using UnityEngine;

namespace FPSShooter.Game.Gameplay.Units.UnitLogic
{
    //TODO: remove it
    // ReSharper disable once ClassNeverInstantiated.Global
    // public sealed class UpgradeWeaponMechanic : IUnitMechanic
    // {
    //     private readonly Animator _animator;
    //     private readonly int _upgradeAnimationBool = Animator.StringToHash("IsInspecting");
    //     private readonly UpgradePanelList _upgradePanelList;
    //
    //     private bool _isUpgradePanelListOpened;
    //
    //     // public UpgradeWeaponMechanic(Animator animator, UpgradePanelList upgradePanelList)
    //     // {
    //     //     _animator = animator;
    //     //     _upgradePanelList = upgradePanelList;
    //     //     _isUpgradePanelListOpened = false;
    //     // }
    //     
    //     public UpgradeWeaponMechanic(Animator animator)
    //     {
    //         _animator = animator;
    //         _isUpgradePanelListOpened = false;
    //     }
    //
    //     public void ToggleUpgradePanel()
    //     {
    //         if (_isUpgradePanelListOpened)
    //         {
    //             _animator.SetBool(_upgradeAnimationBool, false);
    //             // _upgradePanelList.Hide();
    //             _isUpgradePanelListOpened = false;
    //         }
    //         else
    //         {
    //             _animator.SetBool(_upgradeAnimationBool, true);
    //             // _upgradePanelList.Show();
    //             _isUpgradePanelListOpened = true;
    //         }
    //     }
    // }
}