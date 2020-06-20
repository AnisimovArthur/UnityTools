using UnityEngine;

namespace UnityTools.Editor
{
    /// <summary>
    /// Label for toolbar.
    /// </summary>
    public class ToolbarLabel : ToolbarElement
    {
        public ToolbarLabel(string title = "Label", Texture icon = null) : base(title, icon, null) { }

        public override void OnGUI()
        {
            var content = new GUIContent(Title, Icon);

            GUILayout.Label(content);
        }
    }
}
