using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ReUsePool
{

    internal abstract class Pool<T> : IPoolOut<T>, IPoolIn<T>, IPool<T>
    {
        protected int _capacity = 20;
        protected string _poolName = string.Empty;
        private Dictionary<int, T> _dic = new Dictionary<int, T>();

        public void SetPoolName(string poolName)
        {
            _poolName = poolName;
        }

        public virtual T Spawn(string poolName)
        {
            if (_dic.Count <= 0)
            {
                return default(T);
            }

            int key = -1;
            foreach (var kv in _dic)
            {
                key = kv.Key;
                break;
            }
            T t = _dic[key];
            _dic.Remove(key);
            return t;
        }

        public virtual void UnSpawn(string poolName, T t)
        {
            if (_dic.Count >= _capacity)
            {
                ReUseOverflowRelease(t);
                return;
            }

            int hashCode = t.GetHashCode();
            if (!_dic.ContainsKey(hashCode))
            {
                _dic.Add(hashCode, t);
            }
        }

        public abstract void ReUseOverflowRelease(T t);

        public void SetCapacity(int capacity)
        {
            _capacity = capacity;
        }

        public virtual void Clear()
        {
            foreach (var kv in _dic)
            {
                ReUseOverflowRelease(kv.Value);
            }
            _dic.Clear();
        }
    }

}

