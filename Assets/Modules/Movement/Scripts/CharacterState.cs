using UnityEngine;

namespace FPSShooter.Modules.Movement
{
    public struct CharacterState
    {
        public bool Grounded;
        public Stance Stance;
        public Vector3 Velocity;
        public Vector3 Acceleration;
    }
}