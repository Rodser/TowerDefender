using UnityEngine;

namespace EnemySpawn
{
    [CreateAssetMenu(menuName = "Assets/SpawnWavesAsset", fileName = "SpawnWaves", order = 5)]
    public class SpawnWavesAsset : ScriptableObject
    {
        public SpawnWave[] SpawnWaves;
    }
}
