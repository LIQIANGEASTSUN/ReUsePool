using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReUsePool
{
    public class PoolClass<T> : Pool<T> where T : IReUse
    {

        public override T Spawn(string name)
        {
            T t = base.Spawn(name);
            if (null != t)
            {
                t.Spawn();
            }
            return base.Spawn(name);
        }

        public override void UnSpawn(string name, T t)
        {
            base.UnSpawn(name, t);
            t.UnSpawn();
        }

        public override void Release(T t)
        {
            t.Release();
            Debug.LogError("Release:" + t.GetType().Name);
        }
    }
}


