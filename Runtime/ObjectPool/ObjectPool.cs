using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityTools
{
    public class ObjectPool : MonoBehaviour
    {
        private static ObjectPool instance;
        private static ObjectPool Instance
        {
            get
            {
                if (instance == null)
                {
                    var singleton = new GameObject("[UnityTools] ObjectPool").AddComponent<ObjectPool>();
                    instance = singleton;
                }

                return instance;
            }
        }

        [Tooltip("Objects to be instantiated on scene load.")]
        [SerializeField] protected PreloadedPrefab[] m_PreloadedPrefabs;
        [SerializeField] protected bool m_DontDestroyOnLoad;

        /// <summary>
        /// Objects to be instantiated on scene load.
        /// </summary>
        public PreloadedPrefab[] PreloadedPrefabs { get => m_PreloadedPrefabs; }

        private Dictionary<int, Stack<GameObject>> GameObjectPool { get; set; } = new Dictionary<int, Stack<GameObject>>();
        private Dictionary<int, int> InstantiatedGameObjects { get; set; } = new Dictionary<int, int>();
        private static bool IsInitialized { get; set; }

        /// <summary>
        /// Get the object from Pool.
        /// </summary>
        /// <param name="original">The original GameObject to get a copy.</param>
        /// <returns></returns>
        public static GameObject Get(GameObject original)
        {
            return Get(original, Vector3.zero, Quaternion.identity, null);
        }

        /// <summary>
        /// Get the object from Pool.
        /// </summary>
        /// <param name="original">The original GameObject to get a copy.</param>
        /// <param name="position">The position to assign to the pooled object.</param>
        /// <param name="rotation">The rotation to assign to the pooled object.</param>
        /// <returns></returns>
        public static GameObject Get(GameObject original, Vector3 position, Quaternion rotation)
        {
            return Get(original, position, rotation, null);
        }

        /// <summary>
        /// Get the object from Pool.
        /// </summary>
        /// <param name="original">The original GameObject to get a copy.</param>
        /// <param name="position">The position to assign to the pooled object.</param>
        /// <param name="rotation">The rotation to assign to the pooled object.</param>
        /// <param name="parent">The parent to assign to the pooled object.</param>
        /// <returns></returns>
        public static GameObject Get(GameObject original, Vector3 position, Quaternion rotation, Transform parent)
        {
            return Instance.GetInternal(original, position, rotation, parent);
        }

        private GameObject GetInternal(GameObject original, Vector3 position, Quaternion rotation, Transform parent)
        {
            var originalInstanceID = original.GetInstanceID();
            var poolObject = GetExistObject(originalInstanceID);

            if (poolObject == null)
            {
                poolObject = Instantiate(original, position, rotation, parent);
            }
            else
            {
                poolObject.transform.position = position;
                poolObject.transform.rotation = rotation;
                poolObject.transform.SetParent(parent);
                poolObject.SetActive(true);
            }

            InstantiatedGameObjects.Add(poolObject.GetInstanceID(), originalInstanceID);

            return poolObject;
        }

        private GameObject GetExistObject(int originalInstanceID)
        {
            if (GameObjectPool.TryGetValue(originalInstanceID, out Stack<GameObject> pool))
            {
                while (pool.Count > 0)
                {
                    var poolObject = pool.Pop();
                    if (poolObject == null)
                    {
                        continue;
                    }

                    return poolObject;
                }
            }

            return null;
        }

        /// <summary>
        /// Return if the object was instantiated by ObjectPool.
        /// </summary>
        /// <param name="instantiatedObject">The GameObject to check.</param>
        /// <returns>True if the object was instantiated by ObjectPool.</returns>
        public static bool IsPoolObject(GameObject instantiatedObject)
        {
            return Instance.IsPoolObjectInternal(instantiatedObject);
        }

        private bool IsPoolObjectInternal(GameObject instantiatedObject)
        {
            return InstantiatedGameObjects.ContainsKey(instantiatedObject.GetInstanceID());
        }

        /// <summary>
        /// Return the specified GameObject to the ObjectPool.
        /// </summary>
        /// <param name="instantiatedObject">The GameObject to return to the pool</param>
        public static void Return(GameObject instantiatedObject)
        {
            if (instance == null)
            {
                return;
            }

            Instance.ReturnInternal(instantiatedObject);
        }

        private void ReturnInternal(GameObject instantiatedObject)
        {
            var instantiatedInstanceID = instantiatedObject.GetInstanceID();

            if (!InstantiatedGameObjects.TryGetValue(instantiatedInstanceID, out int originalInstanceID))
            {
                Debug.LogError($"{instantiatedObject} is not a Pool Object. To use PoolObject you have to Instantiate object via ObjectPool.Get");
                return;
            }

            InstantiatedGameObjects.Remove(instantiatedInstanceID);

            ReturnInternal(instantiatedObject, originalInstanceID);
        }

        private void ReturnInternal(GameObject instantiatedObject, int originalInstanceID)
        {
            instantiatedObject.SetActive(false);
            instantiatedObject.transform.SetParent(transform);

            if (GameObjectPool.TryGetValue(originalInstanceID, out Stack<GameObject> pool))
            {
                pool.Push(instantiatedObject);
            }
            else
            {
                pool = new Stack<GameObject>();
                pool.Push(instantiatedObject);
                GameObjectPool.Add(originalInstanceID, pool);
            }
        }

        /// <summary>
        /// Preload preafabs manually.
        /// </summary>
        /// <param name="prefabsToPreload">Prefabs to preload</param>
        public static void PreloadPrefabs(PreloadedPrefab[] prefabsToPreload)
        {
            if (prefabsToPreload != null && prefabsToPreload.Length > 0)
            {
                for (int i = 0; i < prefabsToPreload.Length; i++)
                {
                    if (prefabsToPreload[i].Prefab == null || prefabsToPreload[i].Count == 0)
                    {
                        continue;
                    }

                    var instantiatedObjects = new List<GameObject>();

                    for (int j = 0; j < prefabsToPreload[i].Count; j++)
                    {
                        instantiatedObjects.Add(Get(prefabsToPreload[i].Prefab));
                    }

                    for (int j = 0; j < prefabsToPreload[i].Count; j++)
                    {
                        Return(instantiatedObjects[j]);
                    }
                }
            }
        }

        public static void MarkAsDontDestroyOnLoad()
        {
            DontDestroyOnLoad(Instance);
        }

        private void SceneUnloaded(Scene scene)
        {
            IsInitialized = false;
            instance = null;
            SceneManager.sceneUnloaded -= SceneUnloaded;
        }

        private void Start()
        {
            if (PreloadedPrefabs != null && PreloadedPrefabs.Length > 0)
            {
                PreloadPrefabs(PreloadedPrefabs);
            }
        }

        private void OnEnable()
        {
            if (!IsInitialized)
            {
                instance = this;
                IsInitialized = true;
                SceneManager.sceneUnloaded -= SceneUnloaded;
            }
        }

        private void OnDisable()
        {
            SceneManager.sceneUnloaded += SceneUnloaded;
        }

#if UNITY_2019_3_OR_NEWER
        /// <summary>
        /// Reset the static variables for domain reloading.
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void DomainReset()
        {
            IsInitialized = false;
            instance = null;
        }
#endif
    }
}