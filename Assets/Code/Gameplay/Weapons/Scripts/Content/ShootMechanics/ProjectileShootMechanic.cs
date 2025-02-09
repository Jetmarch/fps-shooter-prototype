using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace FPSShooter.Gameplay.Weapons
{
    [Serializable]
    public sealed class ProjectileShootMechanic : BaseShootMechanic
    {
        [SerializeField] private GameObject _projectilePrefab;
        
        public override void Shoot(Transform shootPoint)
        {
            //TODO: Object pooling
            Object.Instantiate(_projectilePrefab, shootPoint.position, shootPoint.rotation);
        }
    }
}