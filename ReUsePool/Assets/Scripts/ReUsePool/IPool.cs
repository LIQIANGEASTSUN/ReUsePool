using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 复用池接口
/// </summary>
public interface IPoolOut<out T>
{
    T Spawn(string name);
}

public interface IPoolIn<in T>
{
    void Recycle(string name, T t);

    void Overflow(T t);
}

public interface IPool<T> : IPoolOut<T>, IPoolIn<T>
{

}



