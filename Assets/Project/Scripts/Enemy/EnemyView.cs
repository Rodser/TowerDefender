﻿using Field;
using UnityEngine;

namespace Enemy
{
    public class EnemyView : MonoBehaviour
    {
        private EnemyData _data;
        private IMovementAgent _movementAgent;

        public EnemyData Data { get => _data; }
        public IMovementAgent MovementAgent { get => _movementAgent; }

        public void AttachData(EnemyData data)
        {
            _data = data;
        }

        public void CreatMovementAgent(GridField grid)
        {
            _movementAgent = new GridMovementAgent(Data.Asset.Speed, transform, grid);
        }
    }
}
