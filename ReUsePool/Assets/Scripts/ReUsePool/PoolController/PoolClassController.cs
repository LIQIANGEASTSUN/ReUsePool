using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ReUsePool
{
    /// <summary>
    /// 类复用池管理：类复用需要继承 IReUse 接口
    /// 一个类创建一个池子， typeof(类).Name 作为池子的名字
    /// </summary>
    public class PoolClassController : PoolControllerBase<IReUse>
    {

        public override IReUse Spawn(string poolName)
        {
            return base.Spawn(poolName);
        }

        public override void UnSpawn(string poolName, IReUse t)
        {
            base.UnSpawn(poolName, t);
        }

        public override void Release(IReUse t)
        {
            base.Release(t);
        }

        protected override Pool<IReUse> CreatePool(string poolName)
        {
            Pool<IReUse> pool = new PoolClass<IReUse>();
            _poolDic.Add(poolName, pool);
            return pool;
        }
    }

}

//public class PoolClassController : IPool<IReUse>
//{
//    private Dictionary<string, Pool<IReUse>> _poolDic = new Dictionary<string, Pool<IReUse>>();

//    public IReUse Spawn(string poolName) 
//    {
//        Pool<IReUse> pool = GetPool(poolName);
//        if (null == pool)
//        {
//            return null;
//        }
//        return pool.Spawn(string.Empty);
//    }

//    public void UnSpawn(string poolName, IReUse t)
//    {
//        Pool<IReUse> pool = GetPool(t);
//        if (null == pool)
//        {
//            pool = CreatePool(t);
//        }
//        pool.UnSpawn(string.Empty, t);
//    }

//    public void Release(IReUse t)
//    {

//    }

//    private Pool<IReUse> CreatePool(IReUse t)
//    {
//        string typeName = TypeName(t);
//        Pool<IReUse> pool = new PoolClass<IReUse>();
//        Debug.LogError("CreatePool:" + typeName);
//        _poolDic.Add(typeName, pool);
//        return pool;
//    }

//    private Pool<IReUse> GetPool(IReUse t)
//    {
//        string typeName = TypeName(t);
//        return GetPool(typeName);
//    }

//    private Pool<IReUse> GetPool(string poolName)
//    {
//        Pool<IReUse> pool = null;
//        _poolDic.TryGetValue(poolName, out pool);
//        return pool;
//    }

//    private string TypeName(IReUse t)
//    {
//        return t.GetType().Name;
//    }

//}
