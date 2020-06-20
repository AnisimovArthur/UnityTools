using UnityEngine;

using UnityEditor;

namespace UnityTools.Editor
{
    /// <summary>
    /// Toolbar popup with a generic menu.
    /// </summary>
    public class ToolbaPopup : ToolbarElement
    {
        public GenericMenu Menu { get; set; }

        public ToolbaPopup(GenericMenu menu, string title = "Popup", Texture icon = null) : base(title, icon, null)
        {
            Menu = menu;
        }

        public override void OnGUI()
        {
            var content = new GUIContent(Title, Icon);

            if (GUILayout.Button(content, EditorStyles.toolbarPopup))
            {
                Menu.ShowAsContext();
            }
        }
    }
}
