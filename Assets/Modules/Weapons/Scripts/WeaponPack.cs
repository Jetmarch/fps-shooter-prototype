using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace FPSShooter.Modules.Gameplay.Weapons
{
    [CreateAssetMenu(fileName = "WeaponPack", menuName = "FPS Shooter/Weapons/WeaponPack")]
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class WeaponPack : SerializedScriptableObject
    {
        [OdinSerialize] private Dictionary<string, WeaponView> _weapons; 
        
        public Dictionary<string, WeaponView> GetWeapons() => _weapons;
    }
}