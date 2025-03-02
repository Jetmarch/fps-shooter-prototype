using System;
using UnityEngine;

namespace FPSShooter.Modules.Utils
{
    public sealed class TriggerDetectorComponent : MonoBehaviour
    {
        public event Action<Collider> TriggerEnter;

        private void OnTriggerEnter(Collider other)
        {
            TriggerEnter?.Invoke(other);
        }
    }
}