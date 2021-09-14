using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Utilities
{
    public static class PoolsManager
    {
        private static Dictionary<Type, object> objectPools = new Dictionary<Type, object>();
        private static Dictionary<Type, PoolableMonoBehaviour> prefabs = new Dictionary<Type, PoolableMonoBehaviour>();

        public static void TryToAddNewPool<T>(ObjectPool<T> pool) where T : PoolableMonoBehaviour
        {
            objectPools.Add(typeof(T), pool);
        }

        public static void Destroy<T>(T objectToDestroy) where T : PoolableMonoBehaviour
        {
            objectToDestroy.OnDestroy();
            if (objectPools.ContainsKey(typeof(T)))
            {
                ((ObjectPool<T>) objectPools[typeof(T)]).Add(objectToDestroy);
            }
            else
            {
                Debug.LogError("Destroying object without creating pool for it");
            }
        }

        public static T Get<T>() where T : PoolableMonoBehaviour
        {
            try
            {
                return ((ObjectPool<T>) objectPools[typeof(T)]).Get();
            }
            catch (InvalidOperationException e)
            {
                if (prefabs.ContainsKey(typeof(T)))
                {
                    var obj = Object.Instantiate(prefabs[typeof(T)]);
                    obj.OnCreate();
                    return obj as T;
                }
            }

            throw new InvalidOperationException($"Can't return object of type: {typeof(T)}");
        }

        public static void SetPrefab(Type type, PoolableMonoBehaviour prefab)
        {
            prefabs.Add(type, prefab);
        }
    }
}