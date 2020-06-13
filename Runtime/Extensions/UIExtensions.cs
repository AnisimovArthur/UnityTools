using System.Collections;

using UnityEngine;
using UnityEngine.UI;

namespace UnityTools
{
    public static class UIExtensions
    {
        /// <summary>
        /// Sets the Horizontal Scroll Position of the ScrollRect.
        /// </summary>
        /// <param name="scrollRect"></param>
        /// <param name="position"></param>
        public static void SetHorizontalScrollPosition(this ScrollRect scrollRect, float position)
        {
            scrollRect.StartCoroutine(SetScrollPositionCoroutine(scrollRect, isVertical: false, position));
        }

        /// <summary>
        /// Sets the Vertical Scroll Position of the ScrollRect.
        /// </summary>
        /// <param name="scrollRect"></param>
        /// <param name="position"></param>
        public static void SetVerticalScrollPosition(this ScrollRect scrollRect, float position)
        {
            scrollRect.StartCoroutine(SetScrollPositionCoroutine(scrollRect, isVertical: true, position));
        }

        private static IEnumerator SetScrollPositionCoroutine(ScrollRect scrollRect, bool isVertical, float position)
        {
            yield return null;

            if (isVertical)
                scrollRect.verticalNormalizedPosition = position;
            else
                scrollRect.horizontalNormalizedPosition = position;

            LayoutRebuilder.ForceRebuildLayoutImmediate(scrollRect.transform as RectTransform);
        }
    }
}
