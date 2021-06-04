using Turret.Weapon;
using UnityEngine;

namespace Turret 
{
    [CreateAssetMenu(menuName = "Assets/TurretAsset", fileName = "Turret")]

    public class TurretAsset : ScriptableObject
    {        
        public TurretView TurretViewPrefab;
        public TurretWeaponAssetBase WeaponAsset;
        public int Price;
    }
}
