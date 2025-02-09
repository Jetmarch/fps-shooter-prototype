using System;
using Sirenix.OdinInspector;

namespace FPSShooter.Gameplay.Weapons
{
    [Serializable]
    public sealed class BaseItemMetadata
    {
        [ShowInInspector, ReadOnly] private Guid _id;
        [ShowInInspector] private string _name;
        [ShowInInspector] private string _description;

        public Guid Id => _id;
        public string Name => _name;
        public string Description => _description;
        
        public BaseItemMetadata(BaseItemMetadata metadata)
        {
            _id = metadata.Id;
            _name = metadata.Name;
            _description = metadata.Description;
        }
    }
}