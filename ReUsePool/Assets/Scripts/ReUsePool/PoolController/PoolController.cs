using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReUsePool
{

    public abstract class PoolController<T> : IPool<T>
    {
        protected Dictionary<string, Pool<T>> _poolDic = new Dictionary<string, Pool<T>>();

        public PoolController()
        {

        }

        public virtual T Spawn(string name)
        {
            Pool<T> pool = GetPool(name);
            if (null == pool)
            {
                return default(T);
            }
            return pool.Spawn(name);
        }

        public virtual void UnSpawn(string name, T t)
        {
            Pool<T> pool = GetPool(t);
            if (null == pool)
            {
                pool = CreatePool(t);
            }
            pool.UnSpawn(name, t);
        }

        public void Release(T t)
        {

        }

        public abstract Pool<T> CreatePool(T t);

        protected Pool<T> GetPool(T t)
        {
            string typeName = TypeName(t);
            return GetPool(typeName);
        }

        protected Pool<T> GetPool(string poolName)
        {
            Pool<T> pool = null;
            _poolDic.TryGetValue(poolName, out pool);
            return pool;
        }

        protected string TypeName(T t)
        {
            return t.GetType().Name;
        }

    }
}

