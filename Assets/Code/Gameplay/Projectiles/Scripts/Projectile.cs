using FPSShooter.Core.Managers;
using UnityEngine;

namespace FPSShooter.Gameplay.Projectiles
{
    public class Projectile : MonoBehaviour, IFixedUpdateListener
    {
        [Header("Ballistics")]
        public float _initialSpeed = 800f; 
        public float _mass = 0.01f;        
        public float _drag = 0.1f;        
        public float _gravityMultiplier = 1f; 
        public Vector3 _velocity;
        private Rigidbody _rigidbody;
        // public float _damageSphereArea = 1f;
        // public int _maxAffectedDamageables = 16;
        
        
        // [SerializeField] private Collider[] _damageables;
        // private int _countOfDamageables;
        
        // Кастомное сопротивление (ρ * v² * C_d * A / 2)
        private const float AirDensity = 1.225f; 
        private const float DragCoefficient = 0.3f; 
        private const float Area = 0.0001f;
    
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.mass = _mass;
            _rigidbody.drag = _drag;
            _rigidbody.velocity = transform.forward * _initialSpeed;
            
            // _damageables = new Collider[_maxAffectedDamageables];
        }
        
        public void OnFixedUpdate(float deltaTime)
        {
            _velocity = _rigidbody.velocity;
            float dragForce = 0.5f * AirDensity * _velocity.sqrMagnitude * DragCoefficient * Area;
            _rigidbody.AddForce(-_velocity.normalized * dragForce);
            
            _rigidbody.AddForce(Physics.gravity * _gravityMultiplier, ForceMode.Acceleration);

            if (_rigidbody.velocity.sqrMagnitude <= 0f)
            {
                Destroy(gameObject);
            }
        }
        
        // private void OnCollisionEnter(Collision other)
        // {
        // if (other.collider.TryGetComponent<BodyPart>(out var targetBodyPart))
        // {
        //     targetBodyPart.Hit(this, other);
        // }
        //
        // //TODO: find the way to not apply splash damage to already hitted enemy
        // _countOfDamageables = Physics.OverlapSphereNonAlloc(other.contacts[0].point, _damageSphereArea, _damageables);
        // for (int i = 0; i < _countOfDamageables; i++)
        // {
        //     if (_damageables[i].TryGetComponent<BodyPart>(out var bodyPart))
        //     {
        //         bodyPart.Splash(this, other);
        //     }
        // }
        //
        // Destroy(gameObject);
        // }
    }
    
    // [Serializable]
    // public sealed class Projectile
    // {
    //     [ShowInInspector] private BaseItemMetadata _itemMetadata;
    //     [ShowInInspector] private float _speed;
    //     [ShowInInspector] private float _lifetime;
    //     [ShowInInspector] private float _damage;
    //     [ShowInInspector] private float _damageRadius;
    //     
    //     //TODO
    //     //OnCollisionEffects
    //     
    //     public BaseItemMetadata ItemMetadata => _itemMetadata;
    //
    //     public Projectile(Projectile projectile)
    //     {
    //         _itemMetadata = new BaseItemMetadata(projectile.ItemMetadata);
    //     }
    //
    //     public void Update(float deltaTime)
    //     {
    //         
    //     }
    //     
    //     public Projectile Clone()
    //     {
    //         return new Projectile(this);
    //     }
    // }
    //
    // [Serializable]
    // public sealed class ProjectileMovement
    // {
    //     
    // }

    public enum ProjectileType
    {
        Bullet,
        Rocket
    }
}