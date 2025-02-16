using System;
using UnityEngine;

namespace FPSShooter.Gameplay.ImpactSystem
{
    public sealed class ObjectStateComponent : MonoBehaviour
    {
        [SerializeField] private ObjectState _objectState;

        private void Start()
        {
            _objectState.Initialize();
        }

        public void Affect(Impact impact)
        {
            _objectState.Affect(impact);
        }
    }
}