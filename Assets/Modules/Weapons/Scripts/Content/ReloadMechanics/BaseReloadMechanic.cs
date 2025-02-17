using System;

namespace FPSShooter.Modules.Gameplay.Weapons
{
    [Serializable]
    public abstract class BaseReloadMechanic
    {
        protected Weapon Owner;
        
        public abstract bool CanReload();
        public abstract void Reload();

        public void SetOwner(Weapon owner)
        {
            Owner = owner;
        }
    }
}