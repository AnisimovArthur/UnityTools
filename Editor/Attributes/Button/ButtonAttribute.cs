using UnityEngine;

namespace UnityTools.Editor
{
    [System.AttributeUsage(System.AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ButtonAttribute : PropertyAttribute
    {
        public string Title { get; private set; }
        public GUIStyle GUIStyle { get; private set; }

        public ButtonAttribute(string text = null)
        {
            Title = text;
            GUIStyle = UnityToolsGUI.Styles.Button;
        }

        public ButtonAttribute(string text, int height) : this(text)
        {
            Title = text;

            GUIStyle.fixedHeight = height;
        }

        public ButtonAttribute(string text, int height, int width) : this(text)
        {
            Title = text;

            GUIStyle.fixedHeight = height;
            GUIStyle.fixedWidth = width;
        }
    }
}