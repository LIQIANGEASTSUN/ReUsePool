using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReUsePool
{

    /// <summary>
    /// UnityEngine.Object 复用池管理：需要是 GameObject
    /// 一个资源名创建一个池子， 资源名作为池子的名字
    /// 注意：不要有重复名字的资源，如果不同资源名字重复了，一定是项目架构中的命名规范有问题
    /// </summary>
    public class PoolObjectController : IPool<UnityEngine.GameObject>
    {
        private Dictionary<string, Pool<UnityEngine.GameObject>> _poolDic = new Dictionary<string, Pool<UnityEngine.GameObject>>();

        public UnityEngine.GameObject Spawn(string resName)
        {
            Pool<UnityEngine.GameObject> pool = GetPool(resName);
            if (null == pool)
            {
                return null;
            }
            return pool.Spawn(resName);
        }

        public void UnSpawn(string resName, UnityEngine.GameObject t)
        {
            Pool<UnityEngine.GameObject> pool = GetPool(resName);
            if (null == pool)
            {
                pool = CreatePool(resName);
            }
            pool.UnSpawn(resName, t);
        }

        public void Release(UnityEngine.GameObject t)
        {

        }

        private Pool<UnityEngine.GameObject> CreatePool(string resName)
        {
            Pool<UnityEngine.GameObject> pool = new PoolGo<UnityEngine.GameObject>();
            Debug.LogError("CreatePool:" + resName);
            _poolDic.Add(resName, pool);
            return pool;
        }

        private Pool<UnityEngine.GameObject> GetPool(string poolName)
        {
            Pool<UnityEngine.GameObject> pool = null;
            _poolDic.TryGetValue(poolName, out pool);
            return pool;
        }
    }

}
