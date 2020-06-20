using UnityEngine;
using UnityEditor;

namespace UnityTools.Editor
{
    /// <summary>
    /// Label for toolbar.
    /// </summary>
    public class ToolbarLabel : ToolbarElement
    {
        public ToolbarLabel(string title = "Label") : base(title, null, null) { }

        public override void OnGUI()
        {
            var content = new GUIContent(Title, Icon);

            GUILayout.Label(content);
        }
    }
}
