using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utils.Pooling
{
    public class GameObjectPool : MonoBehaviour
    {
        private static GameObjectPool s_Instance;

        private static Dictionary<int, Queue<PooledMonoBehaviour>> _pooledObjects = new Dictionary<int, Queue<PooledMonoBehaviour>>();

        private static GameObjectPool Instance
        {
            get
            {
                if(s_Instance == null)
                {
                    s_Instance = FindObjectOfType<GameObjectPool>();
                    if(s_Instance == null)
                    {
                        GameObject gameObj = new GameObject("GameObjectPool");
                        s_Instance = gameObj.AddComponent<GameObjectPool>();
                    }
                    s_Instance.gameObject.SetActive(false);
                }
                return s_Instance;
            }
        }


        public static TMB InstantiatePooled<TMB>(TMB prefab) 
            where TMB : PooledMonoBehaviour
        {
            TMB instance = InstantiatePooledImpl(prefab);
            instance.transform.parent = null;
            return instance;
        }
        public static TMB InstantiatePooled<TMB>(TMB prefab, Vector3 position, Quaternion rotation) 
            where TMB : PooledMonoBehaviour
        {
            TMB instance = InstantiatePooledImpl(prefab);
            instance.transform.parent = null;
            instance.transform.position = position;
            instance.transform.rotation = rotation;
            return instance;
        }
        public static TMB InstantiatePooled<TMB>(TMB prefab, Vector3 position, Quaternion rotation, Transform parent)
            where TMB : PooledMonoBehaviour
        {
            TMB instance = InstantiatePooledImpl(prefab);
            instance.transform.parent = parent;
            instance.transform.position = position;
            instance.transform.rotation = rotation;
            return instance;
        }
        public static TMB InstantiatePooled<TMB>(TMB prefab, Transform parent)
            where TMB : PooledMonoBehaviour
        {
            TMB instance = InstantiatePooledImpl(prefab);
            instance.transform.parent = parent;
            return instance;
        }
        private static TMB InstantiatePooledImpl<TMB>(TMB prefab) 
            where TMB : PooledMonoBehaviour
        {
            int id = prefab.GetInstanceID();
            TMB instance = null;
            if(_pooledObjects.TryGetValue(id,out Queue<PooledMonoBehaviour> queue))
            {
                if(queue.Count > 0)
                {
                    instance = queue.Peek() as TMB;
                    if(instance == null)
                    {
                        throw new NullReferenceException();
                    }

                    queue.Dequeue();
                }
            }
            if(instance == null)
            {
                instance = Instantiate(prefab);
                instance.SetPrefabId(id);
            }
            instance.AwakePooled();
            return instance;
        }

        public static void ReturnObjectToPool(PooledMonoBehaviour instance)
        {
            int id = instance.PrefabId;
            if(_pooledObjects.TryGetValue(id, out Queue<PooledMonoBehaviour> queue))
            {
                queue.Enqueue(instance);
            }
            else
            {
                Queue<PooledMonoBehaviour> newQueue = new Queue<PooledMonoBehaviour>();
                newQueue.Enqueue(instance);
                _pooledObjects[id] = newQueue;
            }

            instance.transform.parent = Instance.transform;
        }
    }
}
