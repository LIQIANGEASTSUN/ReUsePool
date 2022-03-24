using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ReUsePool
{
    public class PoolClassController : PoolController<IReUse>
    {
        public override Pool<IReUse> CreatePool(IReUse t)
        {
            string typeName = TypeName(t);
            Pool<IReUse> pool = new PoolClass<IReUse>();
            _poolDic.Add(typeName, pool);
            return pool;
        }
    }

}
