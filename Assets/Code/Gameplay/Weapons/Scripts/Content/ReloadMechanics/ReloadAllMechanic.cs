using System;

namespace FPSShooter.Gameplay.Weapons
{
    [Serializable]
    public sealed class ReloadAllMechanic : BaseReloadMechanic
    {
        public override bool CanReload()
        {
            return Owner.CurrentAmmo < Owner.MaxAmmo;
        }

        public override void Reload()
        {
            Owner.SetCurrentAmmo(Owner.MaxAmmo);
        }
    }
}