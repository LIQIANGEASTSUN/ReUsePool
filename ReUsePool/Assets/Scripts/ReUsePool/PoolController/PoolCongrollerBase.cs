using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolCongrollerBase : IPool
{
    protected Dictionary<string, IPool> _poolDic = new Dictionary<string, IPool>();

    public abstract T Spawn<T>(string name);

    public abstract void Recycle<T>(string name, T t);


    public abstract void Overflow<T>(T t);

    protected IPool GetPoolCreateIfNot(string name)
    {
        IPool pool = GetPool(name);
        if (null == pool)
        {
            pool = CreatePool(name);
            AddPool(name, pool);
        }
        return pool;
    }

    protected IPool GetPool(string name)
    {
        IPool pool = null;
        _poolDic.TryGetValue(name, out pool);
        return pool;
    }

    protected abstract IPool CreatePool(string name);

    protected void AddPool(string name, IPool pool)
    {
        _poolDic.Add(name, pool);
    }

}
