using Turret;
using UnityEngine;

namespace TurretSpawn
{
    [CreateAssetMenu(menuName = "Assets/TurretMarketAsset", fileName = "TurretMarket")]

    public class TurretMarketAsset : ScriptableObject
    {
        public TurretAsset[] TurretAssets;
    }
}
