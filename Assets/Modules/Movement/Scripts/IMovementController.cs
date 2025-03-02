using UnityEngine;

namespace FPSShooter.Modules.Movement
{
    public interface IMovementController
    {
        void UpdateInput(CharacterInput input);
        void RequestJump();
        void SetPosition(Vector3 position, bool killVelocity = true);
        void SetRotation(Vector3 rotation);
    }
}