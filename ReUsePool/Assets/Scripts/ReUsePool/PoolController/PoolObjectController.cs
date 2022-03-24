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
    public class PoolObjectController : PoolControllerBase<UnityEngine.GameObject>
    {
        public override UnityEngine.GameObject Spawn(string poolName)
        {
            return base.Spawn(poolName);
        }

        public override void UnSpawn(string poolName, UnityEngine.GameObject t)
        {
            base.UnSpawn(poolName, t);
        }

        public override void Release(UnityEngine.GameObject t)
        {
            base.Release(t);
        }

        protected override Pool<GameObject> CreatePool(string poolName)
        {
            Pool<UnityEngine.GameObject> pool = new PoolGo<UnityEngine.GameObject>();
            _poolDic.Add(poolName, pool);
            return pool;
        }
    }

}


//public class PoolObjectController : IPool<UnityEngine.GameObject>
//{
//    private Dictionary<string, Pool<UnityEngine.GameObject>> _poolDic = new Dictionary<string, Pool<UnityEngine.GameObject>>();

//    public UnityEngine.GameObject Spawn(string poolName)
//    {
//        Pool<UnityEngine.GameObject> pool = GetPool(poolName);
//        if (null == pool)
//        {
//            return null;
//        }
//        return pool.Spawn(poolName);
//    }

//    public void UnSpawn(string poolName, UnityEngine.GameObject t)
//    {
//        Pool<UnityEngine.GameObject> pool = GetPool(poolName);
//        if (null == pool)
//        {
//            pool = CreatePool(poolName);
//        }
//        pool.UnSpawn(poolName, t);
//    }

//    public void Release(UnityEngine.GameObject t)
//    {

//    }

//    private Pool<UnityEngine.GameObject> CreatePool(string poolName)
//    {
//        Pool<UnityEngine.GameObject> pool = new PoolGo<UnityEngine.GameObject>();
//        Debug.LogError("CreatePool:" + poolName);
//        _poolDic.Add(poolName, pool);
//        return pool;
//    }

//    private Pool<UnityEngine.GameObject> GetPool(string poolName)
//    {
//        Pool<UnityEngine.GameObject> pool = null;
//        _poolDic.TryGetValue(poolName, out pool);
//        return pool;
//    }
//}