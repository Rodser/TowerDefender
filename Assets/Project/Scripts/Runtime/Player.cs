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

        public IReadOnlyList<EnemyData> EnemyDatas { get => _enemyDatas; }
        public IReadOnlyList<TurretData> TurretDatas { get => _turretDatas; }

        public readonly GridHolder GridHolder;
        public readonly GridField Grid;
        public readonly TurretMarket TurretMarket;
        public readonly EnemySearch EnemySearch;

        public Player()
        {
            GridHolder = Object.FindObjectOfType<GridHolder>();
            GridHolder.CreatGrid();
            Grid = GridHolder.Grid;

            TurretMarket = new TurretMarket(Game.CurrentLevel.TurretMarketAsset);
            EnemySearch = new EnemySearch(_enemyDatas);
        }

        public void EnemySpawned(EnemyData data)
        {
            _enemyDatas.Add(data);
        }

        public void TurretSpawned(TurretData data)
        {
            _turretDatas.Add(data);
        }
    }
}
