using Enemy;

namespace EnemySpawn
{
    [System.Serializable]
    public class SpawnWave
    {
        public EnemyAsset Enemy;
        public int Count;
        public float TimeBetweenSpawn;
        public float TimeBeforeStartWavw;
    }
}
