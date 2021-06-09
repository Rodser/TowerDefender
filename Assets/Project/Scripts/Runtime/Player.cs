using Enemy;
using Field;
using System.Collections.Generic;
using Turret;
using Turret.Weapon;
using TurretSpawn;
using UnityEngine;

namespace Runtime
{
    public class Player
    {
        private List<EnemyData> _enemyDatas = new List<EnemyData>();


        private List<TurretData> _turretDatas = new List<TurretData>();
        private bool _allWavesAreSpawned = false;
        private int _health;

        public IReadOnlyList<EnemyData> EnemyDatas { get => _enemyDatas; }
        public IReadOnlyList<TurretData> TurretDatas { get => _turretDatas; }
        public int Health { get => _health; }
        public event System.Action<int> HealthChanged;

        public readonly GridHolder GridHolder;
        public readonly GridField Grid;
        public readonly TurretMarket TurretMarket;
        public readonly EnemySearch EnemySearch;


        public Player()
        {
            GridHolder = Object.FindObjectOfType<GridHolder>();
            GridHolder.CreatGrid();
            Grid = GridHolder.Grid;

            TurretMarket = new TurretMarket();
            EnemySearch = new EnemySearch(_enemyDatas);
            _health = Game.CurrentLevel.StartHealth;
        }

        public void EnemySpawned(EnemyData data)
        {
            _enemyDatas.Add(data);
        }

        public void EnemyDied(EnemyData data)
        {
            _enemyDatas.Remove(data);
        }

        public void EnemyReachedTarget(EnemyData data)
        {
            _enemyDatas.Remove(data);
        }
        public void LastWaveSpawned()
        {
            _allWavesAreSpawned = true;
        }
        public void ApplyDamage(int damage)
        {
            _health -= damage;
            HealthChanged?.Invoke(_health);
        }
        public void TurretSpawned(TurretData data)
        {
            _turretDatas.Add(data);
        }
        public void CheckForWin()
        {
            if (_allWavesAreSpawned && EnemyDatas.Count == 0)
            {
                GameWon();
            }
        }
        private void GameWon()
        {
            Game.StopPlayer();
            Debug.Log("Win");
        }

        public void CheckForLose()
        {
            if (_health <= 0)
                GameLost();
        }
        private void GameLost()
        {
            Game.StopPlayer();
            Debug.Log("Lose");
        }

        public void Pause()
        {
            Time.timeScale = 0f;
        }
        public void UnPause()
        {
            Time.timeScale = 1f;

        }
    }
}
