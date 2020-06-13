using System.Reflection;

using UnityEngine;

namespace UnityTools.Editor
{
    public static class UnityToolsGUI
    {
        public static UnityToolsStyle Styles { get; private set; } = new UnityToolsStyle();

        public static void Button(UnityEngine.Object target, MethodInfo methodInfo)
        {
            ButtonAttribute buttonAttribute = (ButtonAttribute)methodInfo.GetCustomAttributes(typeof(ButtonAttribute), true)[0];
            string buttonText = string.IsNullOrEmpty(buttonAttribute.Title) ? methodInfo.Name : buttonAttribute.Title;

            if (GUILayout.Button(buttonText, buttonAttribute.GUIStyle))
            {
                methodInfo.Invoke(target, null);
            }
        }
    }
}