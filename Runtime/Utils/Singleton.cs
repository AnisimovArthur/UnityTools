using UnityEngine;

namespace UnityTools
{
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
                    return null;
                }

                lock (Lock)
                {
                    if (instance == null)
                    {
                        instance = FindObjectOfType<T>();

                        if (instance == null)
                        {
                            var singleton = new GameObject("[S] " + typeof(T)).AddComponent<T>();
                            DontDestroyOnLoad(singleton);
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

        public void OnDestroy()
        {
            if (Instance == this)
                ApplicationIsQuitting = true;
        }
    }
}