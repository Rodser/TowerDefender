using Assets;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runtime
{
    public static class Game
    {
        private static Player _player;
        private static AssetRoot _assetRoot;
        private static LevelAsset _currentLevel;
        private static Runner _runner;

        public static Player Player { get => _player; }
        public static AssetRoot AssetRoot { get => _assetRoot; }
        public static LevelAsset CurrentLevel { get => _currentLevel; }

        public static void SetAssetRoot(AssetRoot assetRoot)
        {
            _assetRoot = assetRoot;
        }

        public static void StartLevel(LevelAsset levelAsset)
        {
            _currentLevel = levelAsset;
            AsyncOperation operation = SceneManager.LoadSceneAsync(levelAsset.SceneAsset.name);
            operation.completed += StartPlayer;
        }

        private static void StartPlayer(AsyncOperation operation)
        {
            if (!operation.isDone)
                throw new Exception("Can`t load scene");
            _player = new Player();
            _runner = UnityEngine.Object.FindObjectOfType<Runner>();
            _runner.StartRunning();
        }
        public static void StopPlayer()
        {
            _runner.StopRunning();
        }
    }
}
