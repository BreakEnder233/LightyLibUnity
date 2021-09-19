using LightyLibUnity.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LightyLibUnity.Basic
{
    /// <summary>
    /// Used for all singleton MonoBehavior.
    /// </summary>
    /// <typeparam name="T">The class needed to be singleton.</typeparam>
    public abstract class Singleton<T> where T : Singleton<T>
    {
        private static T _instance;
        /// <summary>
        /// Access to singleton instance.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
#if DEBUG
                    Debug.LogError($"Instance of {typeof(T)} not initiated.");
#else
                throw SingletonAlreadyExistsException.CreateException(typeof(T));
#endif
                }
                return _instance;
            }
            protected set
            {
                _instance = value;
            }
        }
        /// <summary>
        /// Call in awake or earlier.
        /// </summary>
        protected void SetupSingleton()
        {
            if (_instance == null) _instance = (T)this;
            else
            {
#if DEBUG
                Debug.LogError($"Instance of {typeof(T)} already existed!");
#else
                throw SingletonAlreadyExistsException.CreateException(typeof(T));
#endif
                return;
            }
        }

        #region Convenience

        #endregion
    }

}
