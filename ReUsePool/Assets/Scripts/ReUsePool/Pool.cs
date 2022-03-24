using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ReUsePool
{

    public abstract class Pool<T> : IPoolOut<T>, IPoolIn<T>, IPool<T>
    {
        protected int _maxCount = 10;
        private Stack<T> _stack = new Stack<T>();

        public abstract void Release(T t);


        public virtual T Spawn(string name)
        {
            if (_stack.Count > 0)
            {
                return _stack.Pop();
            }
            return default(T);
        }

        public virtual void UnSpawn(string name, T t)
        {
            if (_stack.Count < _maxCount)
            {
                _stack.Push(t);
            }
            else
            {
                Release(t);
            }
        }

        public void SetMax(int value)
        {
            _maxCount = value;
        }

    }

}

