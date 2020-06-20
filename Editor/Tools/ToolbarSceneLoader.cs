using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

namespace UnityTools.Editor
{
    [InitializeOnLoad]
    public static class ToolbarSceneLoader
    {
        private static ToolbaPopup Tool { get; set; }

        /// <summary>
        /// Adds a scene to the generic menu of the tool.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="path"></param>
        public static void AddScene(string name, string path)
        {
            Tool.Menu.AddItem(new GUIContent(name), false, () => OpenScene(path));
        }

        /// <summary>
        /// Adds disabled item-separator to the generic menu of the tool.
        /// </summary>
        /// <param name="name"></param>
        public static void AddSeparator(string name)
        {
            Tool.Menu.AddSeparator(name);
        }

        static ToolbarSceneLoader()
        {
            var menu = new GenericMenu();
            var icon = Resources.Load<Texture>($"{EditorResources.IconsPath}/ToolbarSceneLoader");
            Tool = new ToolbaPopup(menu, "Scenes", icon);

            ToolbarTools.AddTool(Tool, ToolbarSide.Right);
        }

        private static void OpenScene(string path)
        {
            var newPath = path.Contains(".unity") ? path : string.Concat(path, ".unity");
            newPath = string.Concat("Assets/", newPath);

            UnityEditor.SceneManagement.EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            UnityEditor.SceneManagement.EditorSceneManager.OpenScene(newPath);
        }
    }
}
