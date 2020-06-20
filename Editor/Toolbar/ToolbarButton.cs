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
        public ToolbarButton(string title = "Button", Texture icon = null, UnityAction clickAction = null) : base(title, icon, clickAction) { }

        public override void OnGUI()
        {
            var content = new GUIContent(Title, Icon);

            if (GUILayout.Button(content, EditorStyles.toolbarButton))
            {
                ClickAction?.Invoke();
            }
        }
    }
}
