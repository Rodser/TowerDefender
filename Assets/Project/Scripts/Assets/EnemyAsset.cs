using Enemy;
using UnityEngine;

namespace Assets
{
    [CreateAssetMenu(menuName = "Assets/EnemyAsset", fileName = "Enemy", order = 5)]

    public class EnemyAsset : ScriptableObject
    {
        public EnemyView ViewPrefab;
        public int StartHealth;
    }
}
