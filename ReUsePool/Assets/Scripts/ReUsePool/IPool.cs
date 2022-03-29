using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReUsePool
{

    public interface IReUse
    {
        void Spawn();
        void UnSpawn();
        void ReUseOverflowRelease();
    }

    /// <summary>
    /// 复用池协变接口
    /// </summary>
    public interface IPoolOut<out T>
    {
        T Spawn(string name);
    }

    /// <summary>
    /// 复用池逆变接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPoolIn<in T>
    {
        void UnSpawn(string poolName, T t);

        void ReUseOverflowRelease(T t);
    }

    public interface IPoolCapacity
    {
        void SetCapacity(int capacity);
    }

    /// <summary>
    /// 复用池接口
    /// </summary>
    public interface IPool<T> : IPoolOut<T>, IPoolIn<T>, IPoolCapacity
    {
        void Clear();
    }
}
