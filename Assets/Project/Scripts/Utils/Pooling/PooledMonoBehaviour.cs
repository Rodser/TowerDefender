using UnityEngine;

namespace Utils.Pooling
{
    public class PooledMonoBehaviour : MonoBehaviour
    {
        private int _prefabId;

        public int PrefabId { get => _prefabId; }
        public virtual void AwakePooled()
        {            
        }

        public void SetPrefabId(int id)
        {
            _prefabId = id;
        }
    }
}
