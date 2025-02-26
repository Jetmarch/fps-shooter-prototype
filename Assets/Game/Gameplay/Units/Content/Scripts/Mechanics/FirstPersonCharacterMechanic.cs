using FPSShooter.Modules.Core.GameLoop;
using FPSShooter.Modules.FPSCamera;
using FPSShooter.Modules.Movement;
using FPSShooter.Modules.Units;
using UnityEngine;

namespace FPSShooter.Game.Gameplay.Units.UnitLogic
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class FirstPersonCharacterMechanic : IUnitMechanic, IUpdateListener
    {
        private readonly IFPSCameraController _fpsCamera;
        private readonly IMovementController _movementController;

        public FirstPersonCharacterMechanic(IFPSCameraController fpsCamera, IMovementController movementController)
        {
            _fpsCamera = fpsCamera;
            _movementController = movementController;
        }

        public void Move(Vector2 movementVector)
        {
            var lastCharacterInput = new CharacterInput
            {
                Move = movementVector,
                Rotation = _fpsCamera.Rotation,
            };
            _movementController.UpdateInput(lastCharacterInput);
        }
        
        public void Look(Vector2 lookVector)
        {
            _fpsCamera.Look(lookVector);
        }
        
        public void RequestJump()
        {
            _movementController.RequestJump();
        }

        public void OnUpdate(float deltaTime)
        {
            _movementController.UpdateBody(deltaTime);
        }
    }
}