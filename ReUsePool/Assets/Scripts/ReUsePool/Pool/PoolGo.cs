using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReUsePool
{
    public class PoolGo<T> : Pool<T> where T : UnityEngine.Object
    {
        public PoolGo(string poolName)
        {
            SetPoolName(poolName);
        }

        public override T Spawn(string name)
        {
            T t = base.Spawn(name);
            return t;
        }

        public override void UnSpawn(string name, T t)
        {
            base.UnSpawn(name, t);
        }

        public override void Release(T t)
        {
            GameObject.Destroy(t);
        }
    }

}
