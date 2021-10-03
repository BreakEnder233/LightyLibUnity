using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightyLibUnity.Extensions.Container
{
    public static class DictionaryExtension
    {
        public static T2 GetIfExist<T1,T2>(this Dictionary<T1,T2> dictionary, T1 key)
        {
            if (key == null) return default;
            if (dictionary.ContainsKey(key)) return dictionary[key];
            return default;
        }
        public static void AddOrModify<T1, T2>(this Dictionary<T1, T2> dictionary, T1 key, T2 value)
        {
            if (dictionary.ContainsKey(key)) dictionary[key] = value;
            else dictionary.Add(key, value);
        }
    }
}
