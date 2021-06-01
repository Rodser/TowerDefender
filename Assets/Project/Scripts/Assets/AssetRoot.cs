using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    [CreateAssetMenu(menuName ="Assets/AssetRoot",fileName ="AssetRoot",order =5)]
    public class AssetRoot : ScriptableObject
    {
        public List<LevelAsset> Levels;
    }
}
