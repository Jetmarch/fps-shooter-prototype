using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace FPSShooter.Gameplay.Weapons
{
    public sealed class WeaponManager : MonoBehaviour
    {
        [Inject]
        private void Configure(IEnumerable<Weapon> weapons)
        {
            
        }
    }
}
