using System;
using KinematicCharacterController;
using UnityEngine;
// ReSharper disable InconsistentNaming

namespace FPSShooter.Gameplay
{
    [Serializable]
    public sealed class MovementData
    {
        public KinematicCharacterMotor Motor;
        public Transform CameraTarget;
        public Transform Root;
        [Space]
        public float WalkSpeed = 20f;
        public float CrouchSpeed = 7f;
        public float WalkResponce = 25f;
        public float CrouchResponce = 25f;
        [Space]
        public float AirSpeed = 15f;
        public float AirAcceleration = 70f;
        [Space]
        public float JumpSpeed = 20f;
        public float CoyoteTime = 0.2f;
        public float Gravity = -90f;
        [Range(0f, 1f)] public float JumpSustainGravity = 0.4f;
        [Space]
        public float StandHeight = 2f;
        public float CrouchHeight = 1f;
        public float CrouchHeightResponce = 15f;
        [Range(0f, 1f)] public float StandCameraTargetHeight = 0.9f;
        [Range(0f, 1f)] public float CrouchCameraTargetHeight = 0.7f;
    }
}