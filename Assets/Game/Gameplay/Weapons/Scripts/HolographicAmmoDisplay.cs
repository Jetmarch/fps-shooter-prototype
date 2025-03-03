using TMPro;

namespace FPSShooter.Game.Gameplay.Weapons
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class HolographicAmmoDisplay
    {
        private readonly TextMeshPro _ammoText;
        

        public HolographicAmmoDisplay(TextMeshPro ammoText)
        {
            _ammoText = ammoText;
        }
        
        public void SetText(string text)
        {
            _ammoText.text = text;
        }
    }
}