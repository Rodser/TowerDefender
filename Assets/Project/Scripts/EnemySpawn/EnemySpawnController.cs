using Enemy;
using Field;
using Runtime;
using System.Collections;
using UnityEngine;

namespace EnemySpawn
{
    public class EnemySpawnController : IController
    {
        private SpawnWavesAsset _spawnWaves;
        private GridField _grid;
        private IEnumerator _spawnRoutine;
        private float _waitTime;

        public EnemySpawnController(SpawnWavesAsset spawnWaves, GridField grid)
        {
            _spawnWaves = spawnWaves;
            _grid = grid;
        }

        public void OnStart()
        {
            _waitTime = Time.time;
            _spawnRoutine = SpawnRoutine();
        }

        public void OnStop()
        {
        }

        public void Tick()
        {
            if(_waitTime > Time.time)
                return;

            if (_spawnRoutine.MoveNext())
            {
                if(_spawnRoutine.Current is CustomWaitForSeconds waitForSeconds)
                {
                    _waitTime = Time.time + waitForSeconds.Seconds;
                }
            }
        }

        private IEnumerator SpawnRoutine()
        {
            foreach (SpawnWave wave in _spawnWaves.SpawnWaves)
            {
                yield return new CustomWaitForSeconds(wave.TimeBeforeStartWavw);

                for (int i = 0; i < wave.Count; i++)
                {
                    SpawnEnemy(wave.Enemy);
                    if(i < wave.Count - 1)
                    {
                        yield return new CustomWaitForSeconds(wave.TimeBetweenSpawn);
                    }
                }
            }
            Game.Player.LastWaveSpawned();
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
        private class CustomWaitForSeconds
        {
            public readonly float Seconds;

            public CustomWaitForSeconds(float seconds)
            {
                Seconds = seconds;
            }
        }
    }
}
