using UnityEngine;
using UnityEngine.Events;

using UnityEditor;

namespace UnityTools.Editor
{
    /// <summary>
    /// Button for toolbar.
    /// </summary>
    public class ToolbarButton : ToolbarElement
    {
        public ToolbarButton(string title = "Button", UnityAction clickAction = null) : base(title, clickAction) { }

        public override void OnGUI()
        {
            if (GUILayout.Button(Title, EditorStyles.toolbarButton))
            {
                ClickAction?.Invoke();
            }
        }
    }
}
