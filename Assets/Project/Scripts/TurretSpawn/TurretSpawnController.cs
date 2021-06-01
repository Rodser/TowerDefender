using Field;
using Runtime;
using Turret;
using UnityEngine;

namespace TurretSpawn
{
    public class TurretSpawnController : IController
    {
        private GridField _grid;
        private TurretMarket _market;

        public TurretSpawnController(GridField grid, TurretMarket market)
        {
            _grid = grid;
            _market = market;
        }

        public void OnStart()
        {
        }

        public void OnStop()
        {
        }

        public void Tick()
        {
            if (_grid.HasSelectedNode() && Input.GetMouseButtonDown(0))
            {
                Node selectedNode = _grid.GetSelectedNode();

                if (selectedNode.IsOccupied)
                    return;

                SpawnTurret(_market.ChosenTurret, selectedNode);
            }
        }
        private void SpawnTurret(TurretAsset asset, Node node)
        {
            TurretView view = Object.Instantiate(asset.TurretViewPrefab);
            TurretData data = new TurretData(asset, node);

            data.AttachView(view);
            
            node.IsOccupied = true;
            _grid.UpdatePathfinding();
        }
    }
}
