using UnityEngine;

namespace UnityTools
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static object _lock = new object();
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (applicationIsQuitting)
                {
                    return null;
                }

                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = FindObjectOfType<T>();

                        if (_instance == null)
                        {
                            var singleton = new GameObject("[S] " + typeof(T));
                            _instance = singleton.AddComponent<T>();
                            DontDestroyOnLoad(singleton);
                        }
                    }

                    return _instance;
                }
            }
        }

        protected static bool applicationIsQuitting = false;

        private void Awake()
        {
            applicationIsQuitting = false;
        }

        public void OnDestroy()
        {
            if (Instance == this)
                applicationIsQuitting = true;
        }
    }
}