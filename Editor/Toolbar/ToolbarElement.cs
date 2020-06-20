using UnityEngine;
using UnityEngine.Events;

namespace UnityTools.Editor
{
    /// <summary>
    /// Base toolbar element.
    /// </summary>
    public abstract class ToolbarElement
    {
        /// <summary>
        /// Title of the element.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Icon of the element.
        /// </summary>
        public Texture Icon { get; set; }

        /// <summary>
        /// Callback of a click.
        /// </summary>
        public UnityAction ClickAction { get; private set; }

        public ToolbarElement(string title = "", Texture icon = null, UnityAction clickAction = null)
        {
            Title = title;
            Icon = icon;
            ClickAction = clickAction;
        }

        public abstract void OnGUI();
    }
}
