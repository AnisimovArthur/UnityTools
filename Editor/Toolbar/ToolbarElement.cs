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
        /// Callback of a click.
        /// </summary>
        public UnityAction ClickAction { get; private set; }

        public ToolbarElement(string title = "", UnityAction clickAction = null)
        {
            Title = title;
            ClickAction = clickAction;
        }

        public abstract void OnGUI();
    }
}
