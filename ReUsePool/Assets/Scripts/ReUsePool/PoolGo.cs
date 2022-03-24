using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReUsePool
{
    public class PoolGo<T> : Pool<T> where T : UnityEngine.Object
    {
        public override T Spawn(string name)
        {
            T t = base.Spawn(name);
            return base.Spawn(name);
        }

        public override void UnSpawn(string name, T t)
        {
            base.UnSpawn(name, t);
        }

        public override void Release(T t)
        {
            GameObject.Destroy(t);
            Debug.LogError("Release:" + t.GetType().Name);
        }
    }

}
