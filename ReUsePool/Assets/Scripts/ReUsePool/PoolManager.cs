using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReUsePool
{
    public class PoolManager : SingletonObject<PoolManager>
    {
        private PoolClassController poolClassController = new PoolClassController();
        private PoolObjectController poolObjectController = new PoolObjectController();

        public T SpawnClass<T>() where T : class, IReUse
        {
            string poolName = typeof(T).Name;
            IReUse reUse = poolClassController.Spawn(poolName);
            return reUse as T;
        }

        public void UnSpawnClass<T>(T t) where T : class, IReUse
        {
            string poolName = typeof(T).Name;
            poolClassController.UnSpawn(poolName, t);
        }

        public void SetSpawnClassCapacity<T>(int capacity)
        {
            string poolName = typeof(T).Name;
            poolClassController.SetCapacity(poolName, capacity);
        }

        public UnityEngine.GameObject SpawnObject(string resName)
        {
            return poolObjectController.Spawn(resName);
        }

        public void UnSpawnObject(string resName, UnityEngine.GameObject t)
        {
            poolObjectController.UnSpawn(resName, t);
        }

        public void SetSpawnObjectCapacity<T>(int capacity)
        {
            string poolName = typeof(T).Name;
            poolObjectController.SetCapacity(poolName, capacity);
        }

    }
}