using Enemy;
using Field;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime
{
    public class Player
    {
        private List<EnemyData> _enemyDatas;

        public IReadOnlyList<EnemyData> EnemyDatas { get => _enemyDatas; }
        public readonly GridHolder GridHolder;
        public readonly Field.Grid Grid;

        public Player()
        {
            GridHolder = Object.FindObjectOfType<GridHolder>();
            GridHolder.CreatGrid();
            Grid = GridHolder.Grid;
        }

        public void EnemySpawned(EnemyData data)
        {
            _enemyDatas.Add(data);
        }
    }
}
