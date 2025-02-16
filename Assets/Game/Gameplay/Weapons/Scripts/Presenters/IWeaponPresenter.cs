namespace FPSShooter.Gameplay.Weapons
{
    public interface IWeaponPresenter
    {
        public void Shoot();
        public void StartShootAutomatic();
        public void EndShootAutomatic();
        public void Reload();
        public void Update(float deltaTime);
    }
}