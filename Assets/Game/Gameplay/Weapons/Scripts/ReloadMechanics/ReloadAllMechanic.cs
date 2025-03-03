using System;
using FPSShooter.Modules.Gameplay.Weapons;

namespace FPSShooter.Game.Gameplay.Weapons
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

        public override BaseReloadMechanic Clone()
        {
            return new ReloadAllMechanic();
        }
    }
}