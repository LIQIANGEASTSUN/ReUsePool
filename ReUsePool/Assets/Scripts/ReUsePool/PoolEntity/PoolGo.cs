using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolGo : PoolBase
{
    private Stack<UnityEngine.Object> _stack = new Stack<Object>();
    public override T Spawn<T>(string name)
    {
        T t = default(T);
        if (_stack.Count > 0)
        {
            Object obj = _stack.Pop();
            t = (T)obj;
        }
        return t;
    }

    public override void Recycle<T>(string name, T t)
    {
        if (_stack.Count < _maxCount)
        {
            _stack.Push(t);
        }
        else
        {
            Overflow<T>(t);
        }
    }

    public override void Overflow<T>(T t)
    {

    }
}