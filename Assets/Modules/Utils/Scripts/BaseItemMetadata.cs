using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace FPSShooter.Modules.Utils
{
    [Serializable]
    public sealed class BaseItemMetadata
    {
        [OdinSerialize] private Guid _id;
        [SerializeField] private string _name;
        [SerializeField] private string _description;

        public Guid Id => _id;
        public string Name => _name;
        public string Description => _description;
        
        public BaseItemMetadata(BaseItemMetadata metadata)
        {
            _id = Guid.NewGuid();
            _name = metadata.Name;
            _description = metadata.Description;
        }
    }
}