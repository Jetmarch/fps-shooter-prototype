using System;
using UnityEngine;

namespace FPSShooter.Modules.Gameplay.Projectiles
{
    public sealed class CollisionDetectorComponent : MonoBehaviour
    {
        public event Action<Collision> CollisionEnter;
        private void OnCollisionEnter(Collision other)
        {
            CollisionEnter?.Invoke(other);
        }
    }
}