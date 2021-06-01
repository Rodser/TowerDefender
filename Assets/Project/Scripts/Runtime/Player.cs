using Enemy;
using Field;
using System.Collections.Generic;
using TurretSpawn;
using UnityEngine;

namespace Runtime
{
    public class Player
    {
        private List<EnemyData> _enemyDatas = new List<EnemyData>();

        public IReadOnlyList<EnemyData> EnemyDatas { get => _enemyDatas; }
        public readonly GridHolder GridHolder;
        public readonly GridField Grid;
        public readonly TurretMarket TurretMarket;

        public Player()
        {
            GridHolder = Object.FindObjectOfType<GridHolder>();
            GridHolder.CreatGrid();
            Grid = GridHolder.Grid;

            TurretMarket = new TurretMarket(Game.CurrentLevel.TurretMarketAsset);
        }

        public void EnemySpawned(EnemyData data)
        {
            _enemyDatas.Add(data);
        }
    }
}
