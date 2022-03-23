using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolBase : IPool
{
    protected int _maxCount = 10;

    public abstract T Spawn<T>(string name);

    public abstract void Recycle<T>(string name, T t);

    public abstract void Overflow<T>(T t);

}
