using Audio;
using FPSShooter.Modules.Units;

namespace FPSShooter.Game.Gameplay.Units.UnitLogic
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class SoundPlayer : IUnitMechanic
    {
        public void TryPlaySound(string soundName)
        {
            if (AudioManager.Instance.TryGetAudioClipByName(soundName, out var audioClip))
            {
                AudioManager.Instance.PlaySoundOneShot(audioClip, AudioOutput.Master, pitch: UnityEngine.Random.Range(0.7f, 1f));
            }
        }
    }
}