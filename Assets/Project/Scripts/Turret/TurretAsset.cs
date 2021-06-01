using UnityEngine;

namespace Turret 
{
    [CreateAssetMenu(menuName = "Assets/TurretAsset", fileName = "Turret")]

    public class TurretAsset : ScriptableObject
    {
        public int Health;
        public TurretView TurretViewPrefab;
    }
}
