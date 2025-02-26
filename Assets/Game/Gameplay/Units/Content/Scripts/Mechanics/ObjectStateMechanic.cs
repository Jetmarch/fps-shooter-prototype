using FPSShooter.Modules.Gameplay.Impact;
using FPSShooter.Modules.Units;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Units.UnitLogic
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class ObjectStateMechanic : IUnitMechanic, IInitializable
    {
        public ObjectState ObjectState => _objectState;
        public bool IsDead => _objectState.IsDead;

        private readonly ObjectState _objectState;

        public ObjectStateMechanic(ObjectState objectState)
        {
            _objectState = objectState;
        }
        
        public void Initialize()
        {
            _objectState.Initialize();
        }
        
        public ObjectState GetObjectStateData()
        {
            return _objectState;
        }

        public void Affect(ImpactData data)
        {
            _objectState.Affect(data);
        }
    }
}