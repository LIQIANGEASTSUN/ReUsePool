using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReUsePool
{

    public class PoolGoController : IPool<UnityEngine.Object>
    {
        private Dictionary<string, Pool<UnityEngine.Object>> _poolDic = new Dictionary<string, Pool<UnityEngine.Object>>();

        public PoolGoController()
        {

        }

        public UnityEngine.Object Spawn(string name)
        {
            Pool<UnityEngine.Object> pool = GetPool(name);
            if (null == pool)
            {
                return null;
            }
            return pool.Spawn(name);
        }

        public void UnSpawn(string name, UnityEngine.Object t)
        {
            Pool<UnityEngine.Object> pool = GetPool(name);
            if (null == pool)
            {
                pool = CreatePool(t);
            }
            pool.UnSpawn(name, t);
        }

        public void Release(UnityEngine.Object t)
        {

        }

        private Pool<UnityEngine.Object> CreatePool(UnityEngine.Object t)
        {
            string typeName = TypeName(t);
            Pool<UnityEngine.Object> pool = new PoolGo<UnityEngine.Object>();
            _poolDic.Add(typeName, pool);
            return pool;
        }

        private Pool<UnityEngine.Object> GetPool(string poolName)
        {
            Pool<UnityEngine.Object> pool = null;
            _poolDic.TryGetValue(poolName, out pool);
            return pool;
        }

        private string TypeName(UnityEngine.Object t)
        {
            return t.GetType().Name;
        }
    }

}
