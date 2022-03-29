using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReUsePool
{

    internal abstract class PoolControllerBase<T> : IPool<T>
    {
        protected Dictionary<string, IPool<T>> _poolDic = new Dictionary<string, IPool<T>>();

        public virtual T Spawn(string poolName)
        {
            IPool<T> pool = GetPool(poolName);
            if (null == pool)
            {
                return default(T);
            }
            return pool.Spawn(poolName);
        }

        public virtual void UnSpawn(string poolName, T t)
        {
            IPool<T> pool = GetPool(poolName);
            if (null == pool)
            {
                pool = CreatePool(poolName);
            }
            pool.UnSpawn(poolName, t);
        }

        public virtual void Release(T t)
        {

        }

        protected abstract IPool<T> CreatePool(string poolName);

        protected IPool<T> GetPool(string poolName)
        {
            IPool<T> pool = null;
            _poolDic.TryGetValue(poolName, out pool);
            return pool;
        }

        public void SetCapacity(string poolName, int capacity)
        {
            IPool<T> pool = GetPool(poolName);
            if (null == pool)
            {
                pool = CreatePool(poolName);
            }
            pool.SetCapacity(capacity);
        }

        public void SetCapacity(int capacity)
        {
        }

        public virtual void Clear()
        {
            foreach(var kv in _poolDic)
            {
                kv.Value.Clear();
            }
            _poolDic.Clear();
        }

    }

}
