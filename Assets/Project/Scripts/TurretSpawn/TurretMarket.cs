using Turret;

namespace TurretSpawn
{
    public class TurretMarket
    {
        private TurretMarketAsset _asset;

        public TurretMarket(TurretMarketAsset asset)
        {
            _asset = asset;
        }

        public TurretAsset ChosenTurret { get => _asset.TurretAssets[0]; }
    }
}
