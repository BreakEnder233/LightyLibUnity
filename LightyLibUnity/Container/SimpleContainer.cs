using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightyLibUnity.Serialization;
using Newtonsoft.Json;

namespace LightyLibUnity.Container
{
    public class SimpleContainer<T>
    {
        [JsonProperty]
        private Dictionary<string, T> container;
        public SimpleContainer()
        {
            container = new Dictionary<string, T>();
        }
        public bool Exist(string key) => container.ContainsKey(key);
        public T GetOrDefault(string key)
        {
            if (Exist(key)) return container[key];
            return default;
        }
        public void SetOrCreate(string key, T value)
        {
            if (Exist(key)) container[key] = value;
            else container.Add(key, value);
        }
        public void RemoveIfExist(string key)
        {
            if (!Exist(key)) return;
            container.Remove(key);
        }
    }
}
