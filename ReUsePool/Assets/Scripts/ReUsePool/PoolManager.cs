using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReUsePool
{
    /// <summary>
    /// 复用池管理器
    /// 复用池只做存取使用，不参与池对象的创建
    /// 如果从复用池中取不到对象，则需要自己在外部创建
    /// 对象不使用时，将对象放入复用池
    /// </summary>
    public class PoolManager : SingletonObject<PoolManager>
    {
        private PoolClassController poolClassController = new PoolClassController();
        private PoolObjectController poolObjectController = new PoolObjectController();

        /// <summary>
        /// 从复用池中取一个类型为 T 的复用对象
        /// 如果复用池个数大于0，则返回对象，否则返回 default(T)
        /// </summary>
        /// <typeparam name="T">类型，类型名将作为复用池名</typeparam>
        /// <returns></returns>
        public T SpawnClass<T>() where T : class, IReUse
        {
            string poolName = typeof(T).Name;
            IReUse reUse = poolClassController.Spawn(poolName);
            return reUse as T;
        }

        /// <summary>
        /// 将类型为 T 的类对象放入复用池
        /// 如果复用池中数量大于等于 最大容量，则调用 IReUse接口的 Release 方法
        /// </summary>
        public void UnSpawnClass<T>(T t) where T : class, IReUse
        {
            string poolName = t.GetType().Name;
            poolClassController.UnSpawn(poolName, t);
        }

        /// <summary>
        /// 设置类对象复用池容量
        /// </summary>
        public void SetSpawnClassCapacity<T>(int capacity)
        {
            string poolName = typeof(T).Name;
            poolClassController.SetCapacity(poolName, capacity);
        }

        /// <summary>
        /// 从复用池中取一个类型为 GameObject 的复用对象
        /// 如果复用池个数大于0，则返回对象，否则返回 default(GameObject)
        /// </summary>
        /// <param name="resName">资源名，将作为复用池名</param>
        /// <returns></returns>
        public UnityEngine.GameObject SpawnObject(string resName)
        {
            return poolObjectController.Spawn(resName);
        }

        /// <summary>
        /// 将类型为 GameObject 的类对象放入复用池
        /// 如果复用池中数量大于等于 最大容量，则调用 IReUse接口的 Release 方法
        /// </summary>
        public void UnSpawnObject(string resName, UnityEngine.GameObject t)
        {
            poolObjectController.UnSpawn(resName, t);
        }

        /// <summary>
        /// 设置类对象复用池容量
        /// </summary>
        public void SetSpawnObjectCapacity<T>(int capacity)
        {
            string poolName = typeof(T).Name;
            poolObjectController.SetCapacity(poolName, capacity);
        }

        public void Clear()
        {
            poolClassController.Clear();
            poolObjectController.Clear();
        }
    }
}