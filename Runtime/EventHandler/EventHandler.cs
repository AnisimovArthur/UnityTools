using System;
using System.Collections.Generic;

using UnityEngine;

namespace UnityTools
{
    /// <summary>
    /// Generic Event System.
    /// The Event System allows components to Subscribe, Unsubscribe, and Execute events.
    /// </summary>
    public static partial class EventHandler
    {
        private static Dictionary<string, List<InvokableActionBase>> GlobalEventTable { get; set; } = new Dictionary<string, List<InvokableActionBase>>();
        private static Dictionary<object, Dictionary<string, List<InvokableActionBase>>> EventTable { get; set; } = new Dictionary<object, Dictionary<string, List<InvokableActionBase>>>();

        /// <summary>
        /// Executes the global event with no parameters.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        public static void Execute(string eventName)
        {
            var actions = GetActionsByName(eventName);
            if (actions == null)
                return;

            for (int i = actions.Count - 1; i >= 0; i--)
            {
                (actions[i] as InvokableAction)?.Execute();
            }
        }

        /// <summary>
        /// Executes the local object event with no parameters.
        /// </summary>
        /// <param name="obj">The object that the event is attached to.</param>
        /// <param name="eventName">The name of the event.</param>
        public static void Execute(object obj, string eventName)
        {
            var actions = GetActionList(obj, eventName);
            if (actions == null)
                return;

            for (int i = actions.Count - 1; i >= 0; i--)
            {
                (actions[i] as InvokableAction)?.Execute();
            }
        }

        /// <summary>
        /// Subscribes to a global event with no parameters.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="action">The action to call when the event executes.</param>
        public static void Subscribe(string eventName, Action action)
        {
            SubscribeInternal(eventName, new InvokableAction(action));
        }

        /// <summary>
        /// Subscribes to a local object event with no parameters.
        /// </summary>
        /// <param name="obj">The target object.</param>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="action">The action to call when the event executes.</param>
        public static void Subscribe(object obj, string eventName, Action action)
        {
            SubscribeInternal(obj, eventName, new InvokableAction(action));
        }

        /// <summary>
        /// Unubscribes from a global event with no parameters.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="action">The action to remove.</param>
        public static void Unsubscribe(string eventName, Action action)
        {
            var actions = GetActionsByName(eventName);
            if (actions == null)
                return;

            for (int i = 0; i < actions.Count; i++)
            {
                var invokeableAction = actions[i] as InvokableAction;
                if (invokeableAction.IsActionEqual(action))
                {
                    actions.RemoveAt(i);
                    break;
                }
            }

            CheckForEventRemoval(eventName, actions);
        }

        /// <summary>
        /// Unubscribes from a local object event with no parameters.
        /// </summary>
        /// <param name="obj">The object that the event is attached to.</param>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="action">The action to remove.</param>
        public static void Unsubscribe(object obj, string eventName, Action action)
        {
            var actions = GetActionList(obj, eventName);
            if (actions == null)
                return;

            for (int i = 0; i < actions.Count; i++)
            {
                var invokeableAction = (actions[i] as InvokableAction);
                if (invokeableAction.IsActionEqual(action))
                {
                    actions.RemoveAt(i);
                    break;
                }
            }

            CheckForEventRemoval(obj, eventName, actions);
        }

        internal static void SubscribeInternal(string eventName, InvokableActionBase action)
        {
            if (GlobalEventTable.TryGetValue(eventName, out List<InvokableActionBase> actions))
            {
                actions.Add(action);
            }
            else
            {
                actions = new List<InvokableActionBase>();
                actions.Add(action);
                GlobalEventTable.Add(eventName, actions);
            }
        }

        internal static void SubscribeInternal(object obj, string eventName, InvokableActionBase action)
        {
            if (!EventTable.TryGetValue(obj, out Dictionary<string, List<InvokableActionBase>> handlers))
            {
                handlers = new Dictionary<string, List<InvokableActionBase>>();
                EventTable.Add(obj, handlers);
            }

            if (handlers.TryGetValue(eventName, out List<InvokableActionBase> actionList))
            {
                actionList.Add(action);
            }
            else
            {
                actionList = new List<InvokableActionBase>();
                actionList.Add(action);
                handlers.Add(eventName, actionList);
            }
        }

        internal static void CheckForEventRemoval(string eventName, List<InvokableActionBase> actions)
        {
            if (actions.Count == 0)
            {
                GlobalEventTable.Remove(eventName);
            }
        }

        internal static void CheckForEventRemoval(object obj, string eventName, List<InvokableActionBase> actionList)
        {
            if (actionList.Count == 0)
            {
                if (EventTable.TryGetValue(obj, out Dictionary<string, List<InvokableActionBase>> handlers))
                {
                    handlers.Remove(eventName);
                    if (handlers.Count == 0)
                    {
                        EventTable.Remove(obj);
                    }
                }
            }
        }

        internal static List<InvokableActionBase> GetActionsByName(string eventName)
        {
            if (GlobalEventTable.TryGetValue(eventName, out List<InvokableActionBase> actions))
                return actions;

            return null;
        }

        internal static List<InvokableActionBase> GetActionList(object obj, string eventName)
        {
#if UNITY_EDITOR
            if (obj == null)
            {
                Debug.LogError("EventHandler: the target object cannot be null.");
                return null;
            }
#endif

            if (EventTable.TryGetValue(obj, out Dictionary<string, List<InvokableActionBase>> handlers))
            {
                if (handlers.TryGetValue(eventName, out List<InvokableActionBase> actionList))
                {
                    return actionList;
                }
            }

            return null;
        }

#if UNITY_2019_3_OR_NEWER
        /// <summary>
        /// Reset the static variables for domain reloading.
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void DomainReset()
        {
            if (GlobalEventTable != null)
                GlobalEventTable.Clear();

            if (EventTable != null)
                EventTable.Clear();
        }
#endif
    }
}
