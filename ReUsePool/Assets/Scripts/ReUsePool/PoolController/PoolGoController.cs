using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolGoController : PoolCongrollerBase
{

    public override T Spawn<T>(string name)
    {
        IPool pool = GetPoolCreateIfNot(name);
        T t = pool.Spawn<T>(name);
        return t;
    }

    public override void Recycle<T>(string name, T t)
    {
        IPool pool = GetPool(name);
        if (null != pool)
        {
            pool.Recycle<T>(name, t);
        }
    }

    public override void Overflow<T>(T t)
    {

    }

    protected override IPool CreatePool(string name)
    {
        IPool pool = new PoolGo();
        return pool;
    }
}
