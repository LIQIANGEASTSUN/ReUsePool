using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ReUsePool
{

    public abstract class Pool<T> : IPoolOut<T>, IPoolIn<T>, IPool<T>
    {
        protected int _maxCount = 10;
        private Dictionary<int, T> _dic = new Dictionary<int, T>();

        public abstract void Release(T t);


        public virtual T Spawn(string name)
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

        public virtual void UnSpawn(string name, T t)
        {
            if (_dic.Count >= _maxCount)
            {
                Release(t);
                return;
            }

            int hashCode = t.GetHashCode();
            if (!_dic.ContainsKey(hashCode))
            {
                _dic.Add(hashCode, t);
            }
        }

        public void SetMax(int value)
        {
            _maxCount = value;
        }

    }

}

