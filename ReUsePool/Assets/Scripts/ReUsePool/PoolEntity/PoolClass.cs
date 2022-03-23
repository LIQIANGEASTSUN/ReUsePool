using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolClass : PoolBase
{
    private Stack<object> _stack = new Stack<object>();
    public override T Spawn<T>(string name)
    {
        T t = default(T);
        if (_stack.Count > 0)
        {
            t = (T)_stack.Pop();
            ((IReUseClass)t).Spawn();
        }
        return t;
    }

    public override void Recycle<T>(string name, T t)
    {
        if (_stack.Count < _maxCount)
        {
            _stack.Push(t);
            ((IReUseClass)t).Recycle();
        }
        else
        {
            Overflow<T>(t);
        }
    }

    public override void Overflow<T>(T t)
    {
        ((IReUseClass)t).Release();
    }
}
