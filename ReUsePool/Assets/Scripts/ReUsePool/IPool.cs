using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 复用池接口
/// </summary>
public interface IPool
{
    T Spawn<T>(string name);

    void Recycle<T>(string name, T t);

    void Overflow<T>(T t);
}