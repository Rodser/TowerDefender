using Enemy;
using EnemySpawn;
using Field;
using Main;
using System;
using System.Collections.Generic;
using Turret.Weapon;
using TurretSpawn;
using UnityEngine;

namespace Runtime
{
    public class Runner : MonoBehaviour
    {
        private List<IController> _controllers = new List<IController>();
        private bool _isRunning = false;
        private void Update()
        {
            if (!_isRunning)
                return;
            TickControllers();
        }
        public void StartRunning()
        {
            CreateAllControllers();
            OnStartControllers();
            _isRunning = true;
        }
        public void StopRunning()
        {
            OnStopControllers();
            _isRunning = false;
        }
        private void CreateAllControllers()
        {
            _controllers = new List<IController>
            {
                new GridRaycastController(Game.Player.GridHolder),
                new EnemySpawnController(Game.CurrentLevel.SpawnWaves,Game.Player.Grid),
                new TurretSpawnController(Game.Player.Grid,Game.Player.TurretMarket),
                new MovementController(),
                new EnemyReachController(Game.Player.Grid),
                new TurretShootController(),
                new EnemyDeadController(),
                new LoseController(),
                new WinController()
            };
        }
        private void OnStartControllers()
        {
            foreach (IController controller in _controllers)
            {
                try
                {
                    controller.OnStart();
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }
        private void TickControllers()
        {
            foreach (IController controller in _controllers)
            {
                if (!_isRunning)
                {
                    return;
                }
                try
                {
                    controller.Tick();
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }
        private void OnStopControllers()
        {
            foreach (IController controller in _controllers)
            {
                try
                {
                    controller.OnStop();
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }
    }
}
