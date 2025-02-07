using UnityEngine;

namespace FPSShooter.Core.Systems
{
    [CreateAssetMenu(fileName = "InputConfig", menuName = "FPS Shooter/Input Configuration")]
    public sealed class InputConfig : ScriptableObject
    {
        [SerializeField] private KeyCode _fire = KeyCode.Mouse0;
        [SerializeField] private KeyCode _moveForward = KeyCode.W;
        [SerializeField] private KeyCode _moveBackward = KeyCode.S;
        [SerializeField] private KeyCode _moveRight = KeyCode.A;
        [SerializeField] private KeyCode _moveLeft = KeyCode.D;
        [SerializeField] private KeyCode _jump = KeyCode.Space;
        [SerializeField] private string _horizontalAxis = "Horizontal";
        [SerializeField] private string _verticalAxis = "Vertical";
        
        public KeyCode Fire => _fire;
        public KeyCode MoveForward => _moveForward;
        public KeyCode MoveBackward => _moveBackward;
        public KeyCode MoveRight => _moveRight;
        public KeyCode MoveLeft => _moveLeft;
        public KeyCode Jump => _jump;
        public string HorizontalAxis => _horizontalAxis;
        public string VerticalAxis => _verticalAxis;
    }
}