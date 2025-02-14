using UnityEngine;

namespace FPSShooter
{
    [CreateAssetMenu(fileName = "ProjectileConfig", menuName = "FPS Shooter/Projectiles/Projectile Config")]
    public sealed class ProjectileConfig : ScriptableObject
    {
        [Header("Ballistics")]
        [SerializeField] private float _initialSpeed = 800f; 
        [SerializeField] private float _mass = 0.01f;        
        [SerializeField] private float _drag = 0.1f;        
        [SerializeField] private float _gravityMultiplier = 1f;
        [Header("Impact")]
        [SerializeField] private int _damage;
        [SerializeField] private float _impulseForce = 100f;
        
        public float InitialSpeed => _initialSpeed;
        public float Mass => _mass;
        public float Drag => _drag;
        public float GravityMultiplier => _gravityMultiplier;
        public int Damage => _damage;
        public float ImpulseForce => _impulseForce;

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_damage > 0)
            {
                _damage *= -1;
            }
        }
#endif
    }
}