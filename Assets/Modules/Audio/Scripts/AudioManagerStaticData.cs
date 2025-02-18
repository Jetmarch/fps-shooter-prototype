// ReSharper disable InconsistentNaming
namespace Audio
{
    public static class AudioManagerStaticData
    {
        public const string AUDIO_MIXER_RESOURCE_NAME = "Audio/AudioMixer";
        public const string AUDIO_LIBRARY_RESOURCE_NAME = "Audio/AudioLibrary";
        public const string AUDIO_LAYER_SETTING_RESOURCE_NAME = "Audio/AudioLayerSetting";
        
        public const string SOUNDS_MAIN_CHANNEL_NAME = "Master";
        public const string SOUNDS_UI_CHANNEL_NAME = "UI";
        public const string SOUNDS_MUSIC_CHANNEL_NAME = "BackgroundMusic";
        
        public const string PAUSE_SNAPSHOT_NAME = "Pause";
        public const string UNPAUSE_SNAPSHOT_NAME = "UnPause";
        
        public const float TRANSITION_DEFAULT_TIME = 0.001f;
        public const float CHANNEL_VOLUME_DEFAULT = 0.0f;
        public const float CHANNEL_VOLUME_MAXIMUM = 0.0f;
        public const float CHANNEL_VOLUME_MINIMUM = -80.0f;
    }
}
