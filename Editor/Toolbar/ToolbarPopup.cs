using UnityEngine;

using UnityEditor;

namespace UnityTools.Editor
{
    /// <summary>
    /// Toolbar popup with a generic menu.
    /// </summary>
    public class ToolbaPopup : ToolbarElement
    {
        private GenericMenu Menu { get; set; }

        public ToolbaPopup(GenericMenu menu, string title = "Popup") : base(title, null)
        {
            Menu = menu;
        }

        public override void OnGUI()
        {
            if (GUILayout.Button(Title, EditorStyles.toolbarPopup))
            {
                Menu.ShowAsContext();
            }
        }
    }
}
