using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(menuName = "Assets/EnemyAsset", fileName = "Enemy", order = 5)]

    public class EnemyAsset : ScriptableObject
    {
        public EnemyView ViewPrefab;
        public float Speed;
        public float StartHealth;
    }
}
