using System.Collections.Generic;

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

        /// <summary>
        /// Safely removes all children without using DestroyImmediate (safe during physics events).
        /// </summary>
        /// <param name="parent"></param>
        public static void DestroyChildrenImmediateCollisionSafe(this Transform parent)
        {
            var children = new List<GameObject>();
            foreach (Transform child in parent)
            {
                children.Add(child.gameObject);
            }

            foreach (var child in children)
            {
                Object.Destroy(child);
                child.transform.SetParent(null);
            }
        }

        /// <summary>
        /// Safely removes all children without using DestroyImmediate (safe during physics events).
        /// </summary>
        /// <param name="parent"></param>
        public static void DestroyChildrenImmediateCollisionSafe(this RectTransform parent)
        {
            var children = new List<GameObject>();
            foreach (RectTransform child in parent)
            {
                children.Add(child.gameObject);
            }

            foreach (var child in children)
            {
                Object.Destroy(child);
                child.transform.SetParent(null);
            }
        }
    }
}
