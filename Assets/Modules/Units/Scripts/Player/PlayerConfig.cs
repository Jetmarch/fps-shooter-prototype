using FPSShooter.Modules.FPSCamera;
using FPSShooter.Modules.Movement;
using UnityEngine;

namespace FPSShooter.Modules.Units
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "FPS Shooter/Units/Player Config")]
    public sealed class PlayerConfig : ScriptableObject
    {
        [SerializeField] private MovementConfig _movementConfig;
        [SerializeField] private FPSCameraSettings _fpsCameraSettings;
        [SerializeField] private HandsWobbleAnimationData _handsWobbleAnimationData;
        [SerializeField] private HandsFollowCameraLookData _handsFollowCameraLookData;
        [SerializeField] private WeaponSwayEffectData _weaponSwayEffectData;
        
        public MovementConfig MovementConfig => _movementConfig;
        public FPSCameraSettings FPSCameraSettings => _fpsCameraSettings;
        public HandsWobbleAnimationData HandsWobbleAnimationData => _handsWobbleAnimationData;
        public HandsFollowCameraLookData HandsFollowCameraLookData => _handsFollowCameraLookData;
        public WeaponSwayEffectData WeaponSwayEffectData => _weaponSwayEffectData;
    }
}
