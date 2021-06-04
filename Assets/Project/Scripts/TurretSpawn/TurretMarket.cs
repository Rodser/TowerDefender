using Enemy;
using Runtime;
using Turret;
using UnityEngine;

namespace TurretSpawn
{
    public class TurretMarket
    {
        private TurretMarketAsset _asset;
        private int _money;

        public TurretMarket(TurretMarketAsset asset)
        {
            _asset = asset;
            _money = Game.CurrentLevel.StartMoney;
        }

        public TurretAsset ChosenTurret
        {
            get => _money < _asset.TurretAssets[0].Price ? null : _asset.TurretAssets[0];
        }

        public void BuyTurret(TurretAsset turretAsset)
        {
            if(turretAsset.Price > _money)
            {
                Debug.LogError("Not enough money!");
                return;
            }
            _money -= turretAsset.Price;
        }
        public void GetReward(EnemyData enemyData)
        {
            _money += enemyData.Asset.Reward;
        }
    }
}
