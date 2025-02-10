using System;
using KinematicCharacterController;
using UnityEngine;
using VContainer.Unity;

namespace FPSShooter.Gameplay
{
    [Serializable]
    public sealed class MovementController : ICharacterController, IInitializable
    {
        [SerializeField] private MovementData _data;

        private CharacterState _state;
        private CharacterState _lastState;
        private CharacterState _tempState;

        private Quaternion _requestedRotation;
        private Vector3 _requestedMovement;
        private bool _requestedJump;
        private bool _requestedSustainedJump;
        private bool _requestedCrouch;

        private float _timeSinceUngrounded;
        private float _timeSinceJumpRequest;
        private bool _undergroundedDueToJump;

        private Collider[] _uncrouchOverlapResults;

        public MovementController(MovementData data)
        {
            _data = data;
            _state.Stance = Stance.Stand;
            _lastState = _state;
            _uncrouchOverlapResults = new Collider[10];
            _data.Motor.CharacterController = this;
        }

        public void Initialize()
        {
            //Non lazy
        }

        public void UpdateInput(CharacterInput input)
        {
            _requestedRotation = input.Rotation;
            _requestedMovement = new Vector3(input.Move.x, 0f, input.Move.y);
            _requestedMovement = Vector3.ClampMagnitude(_requestedMovement, 1f);
            _requestedMovement = input.Rotation * _requestedMovement;
        }

        public void UpdateBody(float delta)
        {
            var currentHeight = _data.Motor.Capsule.height;
            var normalizeHeight = currentHeight / _data.StandHeight;
            var cameraTargetHeight = currentHeight * (_state.Stance is Stance.Stand ? _data.StandCameraTargetHeight : _data.CrouchCameraTargetHeight);

            var rootTargetScale = new Vector3(1f, normalizeHeight, 1f);

            _data.CameraTarget.localPosition = Vector3.Lerp
                (
                    _data.CameraTarget.localPosition,
                    new Vector3(0f, cameraTargetHeight, 0f),
                    //Much framerate independent formule for lerp
                    1f - Mathf.Exp(-_data.CrouchHeightResponce * delta)
                );

            _data.Root.localScale = Vector3.Lerp
                (
                    _data.Root.localScale,
                    rootTargetScale,
                    1f - Mathf.Exp(-_data.CrouchHeightResponce * delta)
                );
        }

        public void RequestJump()
        {
            var wasRequestingJump = _requestedJump;
            _requestedJump = true;
            if (_requestedJump && !wasRequestingJump)
            {
                _timeSinceJumpRequest = 0f;
            }
        }

        public void RequestSustainedJump(bool state)
        {
            _requestedSustainedJump = state;
        }

        public void RequestCrouch(CrouchInput crouchInput)
        {
            _requestedCrouch = crouchInput switch
                {
                    CrouchInput.Toggle => !_requestedCrouch,
                    CrouchInput.None => _requestedCrouch,
                    _ => _requestedCrouch
                };
        }

        public void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
        {
            
            var forward = Vector3.ProjectOnPlane(_requestedRotation * Vector3.forward, _data.Motor.CharacterUp);

            if (forward != Vector3.zero)
            {
                currentRotation = Quaternion.LookRotation(forward, _data.Motor.CharacterUp);
            }
        }

        public void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
        {
            
            _state.Acceleration = Vector3.zero;

            //if grounded
            if (_data.Motor.GroundingStatus.IsStableOnGround)
            {
                _timeSinceUngrounded = 0f;
                _undergroundedDueToJump = false;

                var groundedMovement = _data.Motor.GetDirectionTangentToSurface(_requestedMovement, _data.Motor.GroundingStatus.GroundNormal) * _requestedMovement.magnitude;
                //Move
                if(_state.Stance is Stance.Stand or Stance.Crouch)
                {
                    var speed = _state.Stance is Stance.Stand ? _data.WalkSpeed : _data.CrouchSpeed;
                    var response = _state.Stance is Stance.Stand ? _data.WalkResponce : _data.CrouchResponce;

                    var targetVelocity = groundedMovement * speed;

                    var moveVelocity = Vector3.Lerp(currentVelocity, targetVelocity, 1f - Mathf.Exp(-response * deltaTime));
                    _state.Acceleration = (moveVelocity - currentVelocity) / deltaTime;

                    currentVelocity = moveVelocity;
                }
            }
            //Air
            else
            {
                _timeSinceUngrounded += deltaTime;

                if(_requestedMovement.sqrMagnitude > 0f)
                {
                    var planarMovement = Vector3.ProjectOnPlane(_requestedMovement, _data.Motor.CharacterUp) * _requestedMovement.magnitude;

                    var currentPlanarVelocity = Vector3.ProjectOnPlane(currentVelocity, _data.Motor.CharacterUp);

                    var movementForce = planarMovement * _data.AirAcceleration * deltaTime;

                    if (currentPlanarVelocity.magnitude < _data.AirSpeed)
                    {
                        var targetPlanarVelocity = currentPlanarVelocity + movementForce;

                        targetPlanarVelocity = Vector3.ClampMagnitude(targetPlanarVelocity, _data.AirSpeed);

                        movementForce = targetPlanarVelocity - currentPlanarVelocity;
                    }
                    else if (Vector3.Dot(currentPlanarVelocity, movementForce) > 0f)
                    {
                        var constrainedMovementForce = Vector3.ProjectOnPlane(movementForce, currentPlanarVelocity.normalized);

                        movementForce = constrainedMovementForce;
                    }

                    //Prevent air-climbing steep slopes
                    if(_data.Motor.GroundingStatus.FoundAnyGround)
                    {
                        if(Vector3.Dot(movementForce, currentVelocity + movementForce) > 0f)
                        {
                            var obstructionNormal = Vector3.Cross(_data.Motor.CharacterUp, Vector3.Cross(_data.Motor.CharacterUp, _data.Motor.GroundingStatus.GroundNormal)).normalized;

                            movementForce = Vector3.ProjectOnPlane(movementForce, obstructionNormal);
                        }
                    }

                    currentVelocity += movementForce;
                }


                //Gravity
                var effectiveGravity = _data.Gravity;
                var verticalSpeed = Vector3.Dot(currentVelocity, _data.Motor.CharacterUp);
                if(_requestedSustainedJump && verticalSpeed > 0f)
                {
                      effectiveGravity *= _data.JumpSustainGravity;
                }

                currentVelocity += _data.Motor.CharacterUp * effectiveGravity * deltaTime;
            }

            if(_requestedJump)
            {
                var grounded = _data.Motor.GroundingStatus.IsStableOnGround;
                var canCoyoteJump = _timeSinceUngrounded < _data.CoyoteTime && !_undergroundedDueToJump;

                if (grounded || canCoyoteJump)
                {
                    _requestedJump = false;
                    _requestedCrouch = false;

                    _data.Motor.ForceUnground(0f);
                    _undergroundedDueToJump = true;

                    var currentVerticalSpeed = Vector3.Dot(currentVelocity, _data.Motor.CharacterUp);
                    var targetVerricalSpeed = Mathf.Max(currentVerticalSpeed, _data.JumpSpeed);
                    currentVelocity += _data.Motor.CharacterUp * (targetVerricalSpeed - currentVerticalSpeed);
                }
                else
                {
                    _timeSinceJumpRequest += deltaTime;

                    var canJumpLater = _timeSinceJumpRequest < _data.CoyoteTime;
                    _requestedJump = canJumpLater;
                }
            }
        }
        public void BeforeCharacterUpdate(float deltaTime)
        {
            _tempState = _state;
            if (_requestedCrouch && _state.Stance is Stance.Stand)
            {
                _state.Stance = Stance.Crouch;
                _data.Motor.SetCapsuleDimensions(_data.Motor.Capsule.radius, _data.CrouchHeight, _data.CrouchHeight * 0.5f);
            }
        }

        public void AfterCharacterUpdate(float deltaTime)
        {
            if (!_requestedCrouch && _state.Stance is not Stance.Stand)
            {
                Uncrouch();
            }

            _state.Grounded = _data.Motor.GroundingStatus.IsStableOnGround;
            _state.Velocity = _data.Motor.Velocity;
            _lastState = _tempState;
        }
        
        public void PostGroundingUpdate(float deltaTime)
        {
            
        }

        public void ProcessHitStabilityReport(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, Vector3 atCharacterPosition, Quaternion atCharacterRotation, ref HitStabilityReport hitStabilityReport)
        {
        }

        public Transform GetCameraTarget() => _data.CameraTarget;

        public void SetPosition(Vector3 position, bool killVelocity = true)
        {
            _data.Motor.SetPosition(position);
            if (killVelocity)
            {
                _data.Motor.BaseVelocity = Vector3.zero;
            }
        }

        public CharacterState GetCurrentState() => _state;
        public CharacterState GetLastState() => _lastState;

        private void Crouch()
        {
            _state.Stance = Stance.Crouch;
            _data.Motor.SetCapsuleDimensions(_data.Motor.Capsule.radius, _data.CrouchHeight, _data.CrouchHeight * 0.5f);
        }

        private void Uncrouch()
        {
            _data.Motor.SetCapsuleDimensions(_data.Motor.Capsule.radius, _data.StandHeight, _data.StandHeight * 0.5f);

            if (_data.Motor.CharacterOverlap(
                    _data.Motor.TransientPosition,
                    _data.Motor.TransientRotation,
                    _uncrouchOverlapResults,
                    _data.Motor.CollidableLayers,
                    QueryTriggerInteraction.Ignore
                    ) > 0)
            {
                Crouch();
            }
            else
            {
                _state.Stance = Stance.Stand;
            }
        }
        
        public bool IsColliderValidForCollisions(Collider coll)
        {
            return true;
        }

        public void OnDiscreteCollisionDetected(Collider hitCollider)
        {
        }

        public void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
        {
        }

        public void OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
        {
        }
    }
}