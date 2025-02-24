using FPSShooter.Modules.Gameplay.Impact;
using FPSShooter.Modules.Gameplay.Weapons;
using FPSShooter.Modules.Units;
using Modules.Units.Scripts.Presenters;
using UnityEngine;

namespace FPSShooter.Game.Gameplay.Units
{
    public sealed class RespawnButtonPresenter : IUnitPresenter
    {
        private readonly UnitView _view;
        private readonly ObjectState _objectState;

        private readonly float _respawnEnemiesCooldown;
        //private readonly EnemySpawner _enemySpawner;

        public RespawnButtonPresenter(UnitView view, ObjectState objectState)
        {
            _view = view;
            _objectState = objectState;
        }
        
        public void Shoot()
        {
            //Not used
        }

        public void ShootStartAutomatic()
        {
            //Not used
        }

        public void ShootEndAutomatic()
        {
            //Not used
        }

        public void Reload()
        {
            //Not used
        }

        public void Move(Vector2 movementVector)
        {
            //Not used
        }

        public void Look(Vector2 lookVector)
        {
            //Not used
        }

        public void RequestJump()
        {
            //Not used
        }

        public void AddWeapon(IWeapon weapon)
        {
            //Not used
        }

        public void SetNextWeapon()
        {
            //Not used
        }

        public void SetPreviousWeapon()
        {
            //Not used
        }

        public void Affect(ImpactData impactData)
        {
            //Not used
            //_enemySpawner.RespawnEnemies();
            Debug.Log("Respawn enemies");
        }

        public void TearApartDeath()
        {
            //Not used
        }

        public void Die()
        {
            //Not used
        }

        public ObjectState GetObjectStateData()
        {
            return _objectState;
        }

        public void Update(float deltaTime)
        {
            
        }
    }
}