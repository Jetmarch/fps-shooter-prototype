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

        private readonly float _respawnEnemiesCooldown;
        private readonly TargetDummyRespawner _targetDummyRespawner;

        public RespawnButtonPresenter(UnitView view, TargetDummyRespawner targetDummyRespawner)
        {
            _view = view;
            _targetDummyRespawner = targetDummyRespawner;
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
            _targetDummyRespawner.RespawnDummies();
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
            return null;
        }

        public void Update(float deltaTime)
        {
            
        }

        public void Resurrect()
        {
            //Not used
        }
    }
}