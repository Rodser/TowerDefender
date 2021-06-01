using Enemy;
using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

namespace Turret.Weapon
{
    public class EnemySearch
    {
        private IReadOnlyList<EnemyData> _enemyDatas;

        public EnemySearch(IReadOnlyList<EnemyData> enemyDatas)
        {
            _enemyDatas = enemyDatas;
        }

        [CanBeNull]
        public EnemyData GetClosestEnemy(Vector3 center, float maxDistance)
        {
            float maxSqrDistance = maxDistance * maxDistance;
            float minSqrDistance = float.MaxValue;
            EnemyData closestEnemy = null;

            foreach (EnemyData enemyData in _enemyDatas)
            {
                float sqrDistane = (enemyData.View.transform.position - center).sqrMagnitude;
                if(sqrDistane > maxSqrDistance)
                    continue;

                if(sqrDistane < minSqrDistance)
                {
                    minSqrDistance = sqrDistane;
                    closestEnemy = enemyData;
                }
            }
            return closestEnemy;
        }
    }
}
