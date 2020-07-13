using System;
using System.Reflection;
using System.Collections.Generic;

using UnityEditor;
using UnityEngine;
#if UNITY_2019_1_OR_NEWER
using UnityEngine.UIElements;
#else
using UnityEngine.Experimental.UIElements;
#endif

namespace UnityTools.Editor
{
    /// <summary>
    /// The side of a tool.
    /// </summary>
    public enum ToolbarSide { Left, Right }

    [InitializeOnLoad]
    public static class ToolbarTools
    {
        private static readonly Type GuiViewType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.GUIView");

#if UNITY_2020_1_OR_NEWER
        private static readonly Type IWindowBackendType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.IWindowBackend");
        private static readonly PropertyInfo WindowBackend = GuiViewType.GetProperty("windowBackend",
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        private static readonly PropertyInfo ViewVisualTree = IWindowBackendType.GetProperty("visualTree",
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
#else
        private static readonly PropertyInfo ViewVisualTree = GuiViewType.GetProperty("visualTree",
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
#endif

        private static readonly List<ToolbarElement> LeftTools = new List<ToolbarElement>();
        private static readonly List<ToolbarElement> RightTools = new List<ToolbarElement>();

        private static ScriptableObject CurrentToolbar { get; set; }

        private const float OffsetLeft = 100;
        private const float OffsetRight = 55;

        /// <summary>
        /// Adds tool to the specified side (left, right).
        /// </summary>
        /// <param name="element">Toolbar element.</param>
        /// <param name="side">The side.</param>
        public static void AddTool(ToolbarElement element, ToolbarSide side)
        {
            var tools = side == ToolbarSide.Left ? LeftTools : RightTools;
            tools.Add(element);
        }

        static ToolbarTools()
        {
            EditorApplication.update -= OnEditorUpdate;
            EditorApplication.update += OnEditorUpdate;
        }

        private static void OnEditorUpdate()
        {
            if (CurrentToolbar == null)
            {
                UpdateToolbar();
            }
        }

        private static void OnGUI()
        {
            var viewHaflWidth = EditorGUIUtility.currentViewWidth / 2;

            var leftRect = new Rect(0, 5, viewHaflWidth - OffsetLeft, Screen.height);
            var rightRect = new Rect(viewHaflWidth + OffsetRight, 5, viewHaflWidth, Screen.height);

            var leftToolsCount = LeftTools.Count;
            var rightToolsCount = RightTools.Count;

            if (leftToolsCount > 0)
            {
                GUILayout.BeginArea(leftRect);
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();

                for (int i = 0; i < leftToolsCount; i++)
                    LeftTools[i].OnGUI();

                GUILayout.EndHorizontal();
                GUILayout.EndArea();
            }

            if (rightToolsCount > 0)
            {
                GUILayout.BeginArea(rightRect);
                GUILayout.BeginHorizontal();

                for (int i = 0; i < rightToolsCount; i++)
                    RightTools[i].OnGUI();

                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
                GUILayout.EndArea();
            }
        }

        private static void UpdateToolbar()
        {
            var toolbars = Resources.FindObjectsOfTypeAll(typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.Toolbar"));
            CurrentToolbar = toolbars.Length > 0 ? toolbars[0] as ScriptableObject : null;

            if (CurrentToolbar != null)
            {
                var toolbarType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.Toolbar");

                // Get visual tree
#if UNITY_2020_1_OR_NEWER
                var windowBackend = WindowBackend.GetValue(CurrentToolbar);

                var visualTree = (VisualElement)ViewVisualTree.GetValue(windowBackend, null);

#else
                var visualTree = (VisualElement)ViewVisualTree.GetValue(CurrentToolbar, null);

#endif

                // Get first child which 'happens' to be toolbar IMGUIContainer
                var container = visualTree[0] as IMGUIContainer;

                var onGUIHandler = typeof(IMGUIContainer).GetField("m_OnGUIHandler", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

                var action = onGUIHandler.GetValue(container) as Action;
                action -= OnGUI;
                action += OnGUI;
                onGUIHandler.SetValue(container, action);
            }
        }
    }
}
