using System;
using KinematicCharacterController;
using UnityEngine;

namespace FPSShooter.Modules.Movement
{
    [Serializable]
    [CreateAssetMenu(fileName = "MovementConfig",menuName = "FPS Shooter/Movement/Movement Config")]
    public sealed class MovementConfig : ScriptableObject
    {
        [Space]
        [SerializeField] private float _walkSpeed = 20f;
        [SerializeField] private float _crouchSpeed = 7f;
        [SerializeField] private float _walkResponce = 25f;
        [SerializeField] private float _crouchResponce = 25f;
        [Space]
        [SerializeField] private float _airSpeed = 15f;
        [SerializeField] private float _airAcceleration = 70f;
        [Space]
        [SerializeField] private float _jumpSpeed = 20f;
        [SerializeField] private float _coyoteTime = 0.2f;
        [SerializeField] private float _gravity = -90f;
        [Range(0f, 1f), SerializeField] private float _jumpSustainGravity = 0.4f;
        [Space]
        [SerializeField] private float _standHeight = 2f;
        [SerializeField] private float _crouchHeight = 1f;
        [SerializeField] private float _crouchHeightResponce = 15f;
        [Range(0f, 1f), SerializeField] private float _standCameraTargetHeight = 0.9f;
        [Range(0f, 1f), SerializeField] private float _crouchCameraTargetHeight = 0.7f;
        
        public float WalkSpeed => _walkSpeed;
        public float CrouchSpeed => _crouchSpeed;
        public float WalkResponce => _walkResponce;
        public float CrouchResponce => _crouchResponce;
        public float AirSpeed => _airSpeed;
        public float AirAcceleration => _airAcceleration;
        public float JumpSpeed => _jumpSpeed;
        public float CoyoteTime => _coyoteTime;
        public float Gravity => _gravity;
        public float JumpSustainGravity => _jumpSustainGravity;
        public float StandHeight => _standHeight;
        public float CrouchHeight => _crouchHeight;
        public float CrouchHeightResponce => _crouchHeightResponce;
        public float StandCameraTargetHeight => _standCameraTargetHeight;
        public float CrouchCameraTargetHeight => _crouchCameraTargetHeight;
    }

    //TODO: Rename it
    [Serializable]
    public sealed class MovementParams
    {
        [SerializeField] private KinematicCharacterMotor _motor;
        [SerializeField] private Transform _cameraTarget;
        [SerializeField] private Transform _root;
        
        public KinematicCharacterMotor Motor => _motor;
        public Transform CameraTarget => _cameraTarget;
        public Transform Root => _root;
    }
}