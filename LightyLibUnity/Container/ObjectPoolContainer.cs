using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightyLibUnity.Container
{
    public class ObjectPoolContainer<T>
    {
        Func<T> createFunc;
        Action<T> enableFunc;
        Action<T> disableFunc;
        protected int capacity = -1;
        protected Queue<T> pool;
        protected List<T> occupiedPool;

        public int poolCount => pool.Count + occupiedPool.Count;
        
        public ObjectPoolContainer(
            Func<T> createFunc,
            Action<T> enableFunc = null,
            Action<T> disableFunc = null, 
            int capacity = -1)
        {
            this.createFunc = createFunc;
            this.enableFunc = enableFunc;
            this.disableFunc = disableFunc;
            this.capacity = capacity;
            if (capacity <= 0)
            {
                pool = new Queue<T>();
                occupiedPool = new List<T>();
            }
            else
            {
                pool = new Queue<T>(capacity);
                occupiedPool = new List<T>(capacity);
            }
        }
        public virtual T Take()
        {
            if(poolCount >= capacity)
            {
                throw new OverflowException("Object pool full");
            }
            if(pool.Count > 0)
            {
                var pickedObject = pool.Peek();
                pool.Dequeue();
                occupiedPool.Add(pickedObject);
                enableFunc?.Invoke(pickedObject);
                return pickedObject;
            }
            else
            {
                var newObject = createFunc.Invoke();
                occupiedPool.Add(newObject);
                enableFunc?.Invoke(newObject);
                return newObject;
            }
        }
        public virtual void Return(T target)
        {
            occupiedPool.Remove(target);
            pool.Enqueue(target);
            disableFunc?.Invoke(target);
        }
    }
}
