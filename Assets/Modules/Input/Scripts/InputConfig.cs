using UnityEngine;

namespace FPSShooter.Core.Systems
{
    [CreateAssetMenu(fileName = "InputConfig", menuName = "FPS Shooter/Input Configuration")]
    public sealed class InputConfig : ScriptableObject
    {
        [SerializeField] private KeyCode _fire = KeyCode.Mouse0;
        [SerializeField] private KeyCode _reload = KeyCode.R;
        [SerializeField] private KeyCode _moveForward = KeyCode.W;
        [SerializeField] private KeyCode _moveBackward = KeyCode.S;
        [SerializeField] private KeyCode _moveRight = KeyCode.D;
        [SerializeField] private KeyCode _moveLeft = KeyCode.A;
        [SerializeField] private KeyCode _jump = KeyCode.Space;
        [SerializeField] private string _mouseX = "Mouse X";
        [SerializeField] private string _mouseY = "Mouse Y";
        [SerializeField] private string _mouseScroll = "Mouse ScrollWheel";
        
        public KeyCode Fire => _fire;
        public KeyCode MoveForward => _moveForward;
        public KeyCode MoveBackward => _moveBackward;
        public KeyCode MoveRight => _moveRight;
        public KeyCode MoveLeft => _moveLeft;
        public KeyCode Jump => _jump;
        public string MouseX => _mouseX;
        public string MouseY => _mouseY;
        public string MouseScroll => _mouseScroll;
        public KeyCode Reload => _reload;
    }
}