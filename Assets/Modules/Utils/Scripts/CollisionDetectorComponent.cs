using System;
using Codice.Client.BaseCommands;
using UnityEngine;

namespace FPSShooter.Modules.Utils
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