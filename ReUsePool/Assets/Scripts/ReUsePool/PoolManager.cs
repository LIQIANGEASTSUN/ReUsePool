using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReUsePool
{
    public class PoolManager : SingletonObject<PoolManager>
    {
        private PoolClassController poolClassController = new PoolClassController();

        public T Spawn<T>() where T : class, IReUse
        {
            string poolName = typeof(T).Name;
            IReUse reUse = poolClassController.Spawn(poolName);
            return reUse as T;
        }

        public void UnSpawn<T>(T t) where T : class, IReUse
        {
            string poolName = typeof(T).Name;
            poolClassController.UnSpawn(poolName, t);
        }

    }
}