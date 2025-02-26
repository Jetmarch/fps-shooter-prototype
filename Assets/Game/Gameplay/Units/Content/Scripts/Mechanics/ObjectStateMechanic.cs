using FPSShooter.Modules.Gameplay.Impact;
using FPSShooter.Modules.Units;

namespace FPSShooter.Game.Gameplay.Units.UnitLogic
{
    public sealed class ObjectStateMechanic : IUnitMechanics
    {
        public ObjectState ObjectState => _objectState;   
        private readonly ObjectState _objectState;

        public ObjectStateMechanic(ObjectState objectState)
        {
            _objectState = objectState;
        }
        
        public ObjectState GetObjectStateData()
        {
            return _objectState;
        }
    }
}