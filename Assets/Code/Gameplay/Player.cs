using FPSShooter.Core.Managers;
using UnityEngine;

namespace FPSShooter.Gameplay
{
    public sealed class Player : MonoBehaviour
    {

        public void RequestFire()
        {
            Debug.Log("RequestFire");
        }

        public void Move(Vector2 movementVector)
        {
            if (movementVector == Vector2.zero) return;
            Debug.Log("Move");
        }

        public void Look(Vector2 lookVector)
        {
            if (lookVector == Vector2.zero) return;
            Debug.Log("Look");
        }

        public void RequestJump()
        {
            Debug.Log("RequestJump");
        }
    }
}
