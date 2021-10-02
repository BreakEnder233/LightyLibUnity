using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightyLibUnity.Container
{
    public class LazyInitContainer<T>
    {
        private readonly Func<T> initFunc;
        private T _Target;
        public T Target
        {
            get
            {
                if (_Target == null) _Target = initFunc.Invoke();
                return _Target;
            }
        }
        public LazyInitContainer(Func<T> initFunc)
        {
            this.initFunc = initFunc;
        }
    }
}
