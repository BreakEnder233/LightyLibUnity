using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LightyLibUnity.Resources
{
    public class ResourceBuffer<T> where T : UnityEngine.Object
    {
        private readonly string route;
        private T _Target;
        public T Target
        {
            get
            {
                if (_Target == null) _Target = UnityEngine.Resources.Load<T>(route);
                return _Target;
            }
        }
        public ResourceBuffer(string route)
        {
            this.route = route;
        }
    }
}
