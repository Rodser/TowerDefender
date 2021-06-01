using Assets;
using UnityEngine;

namespace Runtime
{
    class GameStarter : MonoBehaviour
    {
        [SerializeField]
        private AssetRoot _assetRoot;

        private void Awake()
        {
            Game.SetAssetRoot(_assetRoot);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Game.StartLevel(_assetRoot.Levels[0]);
            }
        }
    }
}
