using UnityEngine;

namespace UnityTools
{
    /// <summary>
    /// Singleton pattern.
    /// There is currently no compatibility with the new Enter Play Mode system.
    /// </summary>
    /// <typeparam name="T">Type of singleton.</typeparam>
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static readonly object Lock = new object();
        protected static bool ApplicationIsQuitting { get; set; } = false;

        private static T instance;
        public static T Instance
        {
            get
            {
                if (ApplicationIsQuitting)
                {
                    Debug.LogError("[S] '" + typeof(T) +
                   "' destroyed. Returning null.");

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

        private void Awake()
        {
            ApplicationIsQuitting = false;
        }

        private void OnApplicationQuit()
        {
            ApplicationIsQuitting = true;
        }

        public void OnDestroy()
        {
            ApplicationIsQuitting = true;
        }
    }
}