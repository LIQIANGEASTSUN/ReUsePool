using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReUsePool
{
    internal class PoolClass<T> : Pool<T> where T : IReUse
    {

        public PoolClass(string poolName)
        {
            SetPoolName(poolName);
        }

        public override T Spawn(string name)
        {
            T t = base.Spawn(name);
            if (null != t)
            {
                t.Spawn();
            }
            return t;
        }

        public override void UnSpawn(string name, T t)
        {
            base.UnSpawn(name, t);
            t.UnSpawn();
        }

        public override void ReUseOverflowRelease(T t)
        {
            t.ReUseOverflowRelease();
        }
    }
}


