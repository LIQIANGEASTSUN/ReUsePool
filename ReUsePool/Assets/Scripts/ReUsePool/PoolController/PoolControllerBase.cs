using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReUsePool
{

    public abstract class PoolControllerBase<T> : IPool<T>
    {
        protected Dictionary<string, Pool<T>> _poolDic = new Dictionary<string, Pool<T>>();

        public virtual T Spawn(string poolName)
        {
            Pool<T> pool = GetPool(poolName);
            if (null == pool)
            {
                return default(T);
            }
            return pool.Spawn(poolName);
        }

        public virtual void UnSpawn(string poolName, T t)
        {
            Pool<T> pool = GetPool(poolName);
            if (null == pool)
            {
                pool = CreatePool(poolName);
            }
            pool.UnSpawn(poolName, t);
        }

        public virtual void Release(T t)
        {

        }

        protected abstract Pool<T> CreatePool(string poolName);

        protected Pool<T> GetPool(string poolName)
        {
            Pool<T> pool = null;
            _poolDic.TryGetValue(poolName, out pool);
            return pool;
        }
    }

}
