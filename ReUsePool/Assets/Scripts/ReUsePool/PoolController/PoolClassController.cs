using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PoolClassController : PoolCongrollerBase
{

    public override T Spawn<T>(string name)
    {
        IPool pool = GetPoolWithType<T>();
        T t = pool.Spawn<T>(name);
        return t;
    }

    public override void Recycle<T>(string name, T t)
    {
        string poolName = TypeName<T>();
        IPool pool = GetPool(poolName);
        if (null != pool)
        {
            pool.Recycle<T>(name, t);
        }
    }

    public override void Overflow<T>(T t)
    {
        ((IReUseClass)t).Release();
    }

    protected override IPool CreatePool(string name)
    {
        IPool pool = new PoolClass();
        return pool;
    }

    private IPool GetPoolWithType<T>()
    {
        string name = TypeName<T>();
        IPool pool = GetPoolCreateIfNot(name);
        return pool;
    }

    private string TypeName<T>()
    {
        return typeof(T).Name;
    }
}
