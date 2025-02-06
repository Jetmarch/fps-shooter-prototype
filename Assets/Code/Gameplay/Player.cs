using FPSShooter.Core.Managers;
using UnityEngine;

namespace FPSShooter.Gameplay
{
    public class Player : MonoBehaviour, IPauseListener
    {
        public void OnPause()
        {
            Debug.Log("Player is paused");
        }

        public void OnResume()
        {
            Debug.Log("Player is resumed");
        }
    }
}
