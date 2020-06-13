using UnityEngine;

namespace UnityTools
{
    public static class TransformExtensions
    {
        /// <summary>
        /// Destroys Transform's children.
        /// </summary>
        /// <param name="parent"></param>
        public static void DestroyChildren(this Transform parent)
        {
            foreach (Transform child in parent)
            {
                Object.Destroy(child.gameObject);
            }
        }

        /// <summary>
        /// Destroys RectTransform's children.
        /// </summary>
        /// <param name="parent"></param>
        public static void DestroyChildren(this RectTransform parent)
        {
            foreach (Transform child in parent)
            {
                Object.Destroy(child.gameObject);
            }
        }

        /// <summary>
        /// Destroys Transform's children immediate.
        /// </summary>
        /// <param name="parent"></param>
        public static void DestroyChildrenImmediate(this Transform parent)
        {
            while (parent.childCount > 0)
            {
                Object.DestroyImmediate(parent.GetChild(0).gameObject);
            }
        }

        /// <summary>
        /// Destroys RectTransform's children immediate.
        /// </summary>
        /// <param name="parent"></param>
        public static void DestroyChildrenImmediate(this RectTransform parent)
        {
            while (parent.childCount > 0)
            {
                Object.DestroyImmediate(parent.GetChild(0).gameObject);
            }
        }
    }
}
