using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReUsePool
{

    public class PoolObjectController : PoolController<UnityEngine.Object>
    {
        public override Pool<UnityEngine.Object> CreatePool(UnityEngine.Object t)
        {
            string typeName = TypeName(t);
            Pool<UnityEngine.Object> pool = new PoolGo<UnityEngine.Object>();
            _poolDic.Add(typeName, pool);
            return pool;
        }
    }

}
