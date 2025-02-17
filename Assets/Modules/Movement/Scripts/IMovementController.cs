namespace FPSShooter.Modules.Movement
{
    public interface IMovementController
    {
        void UpdateInput(CharacterInput input);
        void RequestJump();
        void UpdateBody(float deltaTime);
    }
}