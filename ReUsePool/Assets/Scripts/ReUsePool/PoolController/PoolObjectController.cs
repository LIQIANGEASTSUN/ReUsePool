using UnityEngine;

namespace ReUsePool
{

    /// <summary>
    /// UnityEngine.Object 复用池管理：需要是 GameObject
    /// 一个资源名创建一个池子， 资源名作为池子的名字
    /// 注意：不要有重复名字的资源，如果不同资源名字重复了，一定是项目架构中的命名规范有问题
    /// </summary>
    internal class PoolObjectController : PoolControllerBase<UnityEngine.GameObject>
    {
        public override UnityEngine.GameObject Spawn(string poolName)
        {
            return base.Spawn(poolName);
        }

        protected override IPool<GameObject> CreatePool(string poolName)
        {
            IPool<UnityEngine.GameObject> pool = new PoolGo<UnityEngine.GameObject>(poolName);
            _poolDic.Add(poolName, pool);
            return pool;
        }
    }

}