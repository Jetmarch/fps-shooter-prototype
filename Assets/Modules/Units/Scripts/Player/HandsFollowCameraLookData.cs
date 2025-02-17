using System;
using UnityEngine;

namespace FPSShooter.Modules.Units
{
    [Serializable]
    public sealed class HandsFollowCameraLookData
    {
        [SerializeField] private float _handsFollowSpeed = 25;
        public float HandsFollowSpeed => _handsFollowSpeed;
    }
}