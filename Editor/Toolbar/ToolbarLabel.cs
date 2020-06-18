using UnityEngine;

namespace UnityTools.Editor
{
    /// <summary>
    /// Label for toolbar.
    /// </summary>
    public class ToolbarLabel : ToolbarElement
    {
        public ToolbarLabel(string title = "Label") : base(title, null) { }

        public override void OnGUI()
        {
            GUILayout.Label(Title);
        }
    }
}
