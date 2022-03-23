using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolControllerType
{
    None,
    GameObject,
    ReUseClass,
}

public class PoolManager : SingletonObject<PoolManager>, IPool
{
    private Dictionary<PoolControllerType, IPool> _poolControllerDic = new Dictionary<PoolControllerType, IPool>();

    public PoolManager()
    {
        _poolControllerDic[PoolControllerType.GameObject] = new PoolGoController();
        _poolControllerDic[PoolControllerType.ReUseClass] = new PoolClassController();
    }

    public T Spawn<T>(string name)
    {
        IPool pool = GetPool<T>();
        if (null != pool)
        {
            return pool.Spawn<T>(name);
        }
        return default(T);
    }

    public void Recycle<T>(string name, T t)
    {
        IPool pool = GetPool<T>();
        if (null != pool)
        {
            pool.Recycle<T>(name, t);
        }
    }

    public void Overflow<T>(T t)
    {
        
    }

    private IPool GetPool<T>()
    {
        PoolControllerType type = GetPoolControllerType<T>();
        IPool pool = null;
        _poolControllerDic.TryGetValue(type, out pool);
        return pool;
    }

    private PoolControllerType GetPoolControllerType<T>()
    {
        if (typeof(GameObject).GetType() == typeof(T).GetType())
        {
            return PoolControllerType.GameObject;
        }

        if (typeof(IReUseClass).IsAssignableFrom(typeof(T)))
        {
            return PoolControllerType.GameObject;
        }
        return PoolControllerType.None;
    }

}
