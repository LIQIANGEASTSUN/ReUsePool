using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ReUsePool
{
    public class PoolClassController : IPool<IReUse>
    {
        private Dictionary<string, Pool<IReUse>> _poolDic = new Dictionary<string, Pool<IReUse>>();

        public PoolClassController()
        {

        }

        public IReUse Spawn(string name)
        {
            Pool<IReUse> pool = GetPool(name);
            if (null == pool)
            {
                return null;
            }
            return pool.Spawn(name);
        }

        public void UnSpawn(string name, IReUse t)
        {
            Pool<IReUse> pool = GetPool(t);
            if (null == pool)
            {
                pool = CreatePool(t);
            }
            pool.UnSpawn(name, t);
        }

        public void Release(IReUse t)
        {

        }

        private Pool<IReUse> CreatePool(IReUse t)
        {
            string typeName = TypeName(t);
            Pool<IReUse> pool = new PoolClass<IReUse>();
            _poolDic.Add(typeName, pool);
            return pool;
        }

        private Pool<IReUse> GetPool(IReUse t)
        {
            string typeName = TypeName(t);
            return GetPool(typeName);
        }

        private Pool<IReUse> GetPool(string poolName)
        {
            Pool<IReUse> pool = null;
            _poolDic.TryGetValue(poolName, out pool);
            return pool;
        }

        private string TypeName(IReUse t)
        {
            return t.GetType().Name;
        }

    }

}
