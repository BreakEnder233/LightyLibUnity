using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LightyLibUnity.Serialization
{
    public abstract class LightySerializableComponent : MonoBehaviour, LightyISerializable
    {
        public abstract string ToSerializedString();
        public abstract void FromSerializedString(string serializedData);
        public static T UnserializeComponent<T>(GameObject gameObject, string dataString) where T : LightySerializableComponent
        {
            var type = typeof(T);
            return UnserializeComponent(gameObject, type, dataString) as T;
        }
        public static LightySerializableComponent UnserializeComponent(GameObject gameObject, Type T, string dataString)
        {
            if (!T.IsSubclassOf(typeof(LightySerializableComponent)))
            {
                Debug.LogError($"Class {T} is not subclass of {nameof(LightySerializableComponent)}");
                return null;
            }
            var component = gameObject.AddComponent(T) as LightySerializableComponent;
            component.FromSerializedString(dataString);
            return component;
        }
    }
}
