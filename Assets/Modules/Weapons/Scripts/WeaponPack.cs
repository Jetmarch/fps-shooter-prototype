using System.Collections.Generic;
using UnityEngine;

namespace FPSShooter.Modules.Gameplay.Weapons
{
    [CreateAssetMenu(fileName = "WeaponPack", menuName = "FPS Shooter/Weapons/WeaponPack")]
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class WeaponPack : ScriptableObject
    {
        [SerializeField] private List<WeaponView> _weapons;
        
        public List<WeaponView> GetWeapons() => _weapons; 
    }
}