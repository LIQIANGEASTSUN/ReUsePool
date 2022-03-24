using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReUsePool
{
    public class PoolManager : SingletonObject<PoolManager>
    {
        private PoolController<IReUse> _poolClassController;
        private PoolController<UnityEngine.Object> _poolObjectController;
        public PoolManager()
        {
            _poolClassController = new PoolClassController();
            _poolObjectController = new PoolObjectController();
        }

        public IReUse SpawnClass(string name)
        {
            return _poolClassController.Spawn(name);
        }

        public void UnSpawnClass<T>(string name, T t) where T : IReUse
        {
            _poolClassController.UnSpawn(name, t);
        }

        public UnityEngine.Object SpawnObject(string name)
        {
            return _poolObjectController.Spawn(name);
        }

        public void UnSpawnObject<T>(string name, T t) where T : UnityEngine.Object
        {
            _poolObjectController.UnSpawn(name, t);
        }
    }

}