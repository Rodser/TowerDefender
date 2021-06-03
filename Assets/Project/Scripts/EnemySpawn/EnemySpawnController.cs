using Enemy;
using Field;
using Runtime;
using UnityEngine;

namespace EnemySpawn
{
    public class EnemySpawnController : IController
    {
        private SpawnWavesAsset _spawnWaves;
        private GridField _grid;
        private float _startTime;
        private float _passedTimeAtPreviousTime = -1f;

        public EnemySpawnController(SpawnWavesAsset spawnWaves, GridField grid)
        {
            _spawnWaves = spawnWaves;
            _grid = grid;
        }

        public void OnStart()
        {
            _startTime = Time.time;
        }

        public void OnStop()
        {
        }

        public void Tick()
        {
            float passedTime = Time.time - _startTime;
            float timeToSpawn = 0f;

            foreach (SpawnWave wave in _spawnWaves.SpawnWaves)
            {
                timeToSpawn += wave.TimeBeforeStartWavw;
                for (int i = 0; i < wave.Count; i++)
                {
                    if (passedTime >= timeToSpawn && _passedTimeAtPreviousTime < timeToSpawn)
                        SpawnEnemy(wave.Enemy);

                    if(i < wave.Count -1)
                        timeToSpawn += wave.TimeBetweenSpawn;
                }
            }

            _passedTimeAtPreviousTime = passedTime;
        }

        private void SpawnEnemy(EnemyAsset asset)
        {
            EnemyView view = Object.Instantiate(asset.ViewPrefab);
            view.transform.position = _grid.GetStartNode().Position;
            EnemyData data = new EnemyData(asset);

            data.AttachView(view);
            view.CreatMovementAgent(_grid);

            Game.Player.EnemySpawned(data);
        }
    }
}
