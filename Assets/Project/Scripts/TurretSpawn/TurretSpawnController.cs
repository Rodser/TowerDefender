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

                TurretAsset asset = _market.ChosenTurret;
                if(asset != null)
                {
                    _market.BuyTurret(asset);
                    SpawnTurret(asset, selectedNode);
                }
                else
                {
                    Debug.Log("Not enough money!");
                }
            }
        }
        private void SpawnTurret(TurretAsset asset, Node node)
        {
            TurretView view = Object.Instantiate(asset.TurretViewPrefab);
            TurretData data = new TurretData(asset, node);

            data.AttachView(view);
            Game.Player.TurretSpawned(data);
            
            node.IsOccupied = true;
            _grid.UpdatePathfinding();
        }
    }
}
