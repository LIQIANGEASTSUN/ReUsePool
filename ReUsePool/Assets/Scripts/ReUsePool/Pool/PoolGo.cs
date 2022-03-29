using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReUsePool
{
    internal class PoolGo<T> : Pool<T> where T : UnityEngine.Object
    {
        public PoolGo(string poolName)
        {
            SetPoolName(poolName);
        }

        public override T Spawn(string name)
        {
            T t = base.Spawn(name);
            if (null != t && t is GameObject)
            {
                (t as GameObject).SetActive(true);
            }
            return t;
        }

        public override void UnSpawn(string poolName, T t)
        {
            if (null != t && t is GameObject)
            {
                (t as GameObject).SetActive(false);
            }
            base.UnSpawn(poolName, t);
        }

        public override void ReUseOverflowRelease(T t)
        {
            GameObject.Destroy(t);
        }
    }

}
