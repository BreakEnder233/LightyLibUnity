using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightyLibUnity.Extensions.Resources
{
    public static class ResourcesExtension
    {
        public static T Load<T>(params string[] routes) where T : UnityEngine.Object
        {
            return UnityEngine.Resources.Load<T>(Path.Combine(routes));
        }
    }
}
