using Enemy;
using Runtime;
using Turret;
using UnityEngine;

namespace TurretSpawn
{
    public class TurretMarket
    {
        private TurretAsset _chooseTurret;
        private int _money;

        public TurretMarket()
        {
            _money = Game.CurrentLevel.StartMoney;
        }

        public TurretAsset ChosenTurret
        {
            get => _chooseTurret.Price >= _money ? null : _chooseTurret;
        }
        public void ChooseTurret(TurretAsset asset)
        {
            _chooseTurret = asset;
        }
        public int Money { get => _money; }
        public event System.Action<int> MoneyChanged;

        public void BuyTurret(TurretAsset turretAsset)
        {
            if(turretAsset.Price > _money)
            {
                Debug.LogError("Not enough money!");
                return;
            }
            _money -= turretAsset.Price;
            MoneyChanged?.Invoke(_money);
        }
        public void GetReward(EnemyData enemyData)
        {
            _money += enemyData.Asset.Reward;
            MoneyChanged?.Invoke(_money);
        }
    }
}
