using Field;
using Runtime;
using System.Collections.Generic;

namespace Enemy
{
    class EnemyReachController : IController
    {
        private Node _targetNode;
        private List<EnemyData> _reachedEnemyDatas = new List<EnemyData>();

        public EnemyReachController(GridField grid)
        {
            _targetNode = grid.GetTargetNode();
        }

        public void OnStart()
        {
        }

        public void OnStop()
        {
        }

        public void Tick()
        {
            foreach (EnemyData data in Game.Player.EnemyDatas)
            {
                if (data.IsDead)
                    continue;

                if(data.View.MovementAgent.GetCurrentNode() == _targetNode)
                {
                    Game.Player.ApplyDamage(data.Asset.Damage);
                    _reachedEnemyDatas.Add(data);
                    data.ReachedTarget();
                }
            }
            foreach (EnemyData data in _reachedEnemyDatas)
            {
                Game.Player.EnemyReachedTarget(data);
            }
            _reachedEnemyDatas.Clear();
        }
    }
}
