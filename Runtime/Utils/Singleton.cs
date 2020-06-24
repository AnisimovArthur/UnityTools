using UnityEngine;

namespace UnityTools
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static object Lock { get; set; } = new object();

        private static T instance;
        public static T Instance
        {
            get
            {
                lock (Lock)
                {
                    if (instance == null)
                    {
                        instance = FindObjectOfType<T>();

                        if (instance == null)
                        {
                            var singleton = new GameObject("[S] " + typeof(T));
                            instance = singleton.AddComponent<T>();
                            DontDestroyOnLoad(singleton);
                        }
                    }

                    return instance;
                }
            }
        }
    }
}