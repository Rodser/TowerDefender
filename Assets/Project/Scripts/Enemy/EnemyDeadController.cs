using Runtime;
using System.Collections.Generic;

namespace Enemy
{
    class EnemyDeadController : IController
    {
        private List<EnemyData> _diedEnemyDatas = new List<EnemyData>();
        public void OnStart()
        {
        }

        public void OnStop()
        {
        }

        public void Tick()
        {
            foreach (EnemyData enemyData in Game.Player.EnemyDatas)
            {
                if(enemyData.IsDead)
                {
                    _diedEnemyDatas.Add(enemyData);
                    Game.Player.TurretMarket.GetReward(enemyData);
                    enemyData.Die();
                }
            }
            foreach (EnemyData enemyData in _diedEnemyDatas)
            {
                Game.Player.EnemyDied(enemyData);
            }

            _diedEnemyDatas.Clear();
        }
    }
}
