using UnityEngine;

namespace UnityTools
{
    public class UnityToolsStyle
    {
        public GUIStyle Button;

        public UnityToolsStyle()
        {
            Button = GetButonSkin();
        }

        private GUIStyle GetButonSkin()
        {
            var style = GUI.skin.button;
            return style;
        }
    }
}