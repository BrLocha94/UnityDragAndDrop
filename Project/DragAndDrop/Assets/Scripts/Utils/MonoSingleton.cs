using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Main
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private static T _instance;
        public static T instance
        {
            get
            {
                if (_instance == null)
                    Debug.Log("Instance not initialized");

                return _instance;
            }
        }

        void Awake()
        {
            _instance = this as T;

            InitializeOnAwake();
        }

        //Use this method override to initialize on Awake method
        protected virtual void InitializeOnAwake() { }
    }
}