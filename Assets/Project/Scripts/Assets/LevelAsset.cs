using EnemySpawn;
using UnityEditor;
using UnityEngine;

namespace Assets
{
    [CreateAssetMenu(menuName = "Assets/LevelAsset", fileName = "Level")]
    public class LevelAsset : ScriptableObject
    {
        public SceneAsset SceneAsset;
        public SpawnWavesAsset SpawnWaves;
    }
}
