using UnityEngine;

namespace UnityTools
{
    /// <summary>
    /// Singleton pattern.
    /// </summary>
    /// <typeparam name="T">Type of singleton.</typeparam>
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static readonly object Lock = new object();
        protected static bool ApplicationIsQuitting { get; set; } = false;

        protected static T instance;
        public static T Instance
        {
            get
            {
                if (ApplicationIsQuitting)
                {
                    return null;
                }

                lock (Lock)
                {
                    if (instance == null)
                    {
                        instance = FindObjectOfType<T>();

                        if (instance == null)
                        {
                            var singletonObject = new GameObject("[S] " + typeof(T));
                            instance = singletonObject.AddComponent<T>();
                            DontDestroyOnLoad(singletonObject);
                        }
                    }

                    return instance;
                }
            }
        }

        protected virtual void Awake()
        {
            ApplicationIsQuitting = false;
        }

        protected virtual void OnApplicationQuit()
        {
            ApplicationIsQuitting = true;
        }

        protected virtual void OnDestroy()
        {
            ApplicationIsQuitting = true;
        }
    }
}