using System;
using System.Collections.Generic;

using UnityEngine;

namespace UnityTools
{
    /// <summary>
    /// Generic Event System.
    /// The Event System allows components to Subscribe, Unsubscribe, and Execute events.
    /// </summary>
    public static class EventHandler
    {
        private static Dictionary<string, List<InvokableActionBase>> GlobalEventTable { get; set; } = new Dictionary<string, List<InvokableActionBase>>();

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
        /// Executes the global event with one parameter.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="arg1">The first parameter.</param>
        public static void Execute<T1>(string eventName, T1 arg1)
        {
            var actions = GetActionsByName(eventName);
            if (actions == null)
                return;

            for (int i = actions.Count - 1; i >= 0; i--)
            {
                (actions[i] as InvokableAction<T1>)?.Execute(arg1);
            }
        }

        /// <summary>
        /// Executes the global event with one parameter.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        public static void Execute<T1, T2>(string eventName, T1 arg1, T2 arg2)
        {
            var actions = GetActionsByName(eventName);
            if (actions == null)
                return;

            for (int i = actions.Count - 1; i >= 0; i--)
            {
                (actions[i] as InvokableAction<T1, T2>)?.Execute(arg1, arg2);
            }
        }

        /// <summary>
        /// Executes the global event with one parameter.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <param name="arg3">The third parameter.</param>
        public static void Execute<T1, T2, T3>(string eventName, T1 arg1, T2 arg2, T3 arg3)
        {
            var actions = GetActionsByName(eventName);
            if (actions == null)
                return;

            for (int i = actions.Count - 1; i >= 0; i--)
            {
                (actions[i] as InvokableAction<T1, T2, T3>)?.Execute(arg1, arg2, arg3);
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
        /// Subscribes to a global event with one parameter.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="action">The action to call when the event executes.</param>
        public static void Subscribe<T1>(string eventName, Action<T1> action)
        {
            SubscribeInternal(eventName, new InvokableAction<T1>(action));
        }

        /// <summary>
        /// Subscribes to a global event with two parameters.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="action">The action to call when the event executes.</param>
        public static void Subscribe<T1, T2>(string eventName, Action<T1, T2> action)
        {
            SubscribeInternal(eventName, new InvokableAction<T1, T2>(action));
        }

        /// <summary>
        /// Subscribes to a global event with three parameters.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="action">The action to call when the event executes.</param>
        public static void Subscribe<T1, T2, T3>(string eventName, Action<T1, T2, T3> action)
        {
            SubscribeInternal(eventName, new InvokableAction<T1, T2, T3>(action));
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
                }
            }

            CheckForEventRemoval(eventName, actions);
        }

        /// <summary>
        /// Unubscribes from a global event with one parameter.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="action">The action to remove.</param>
        public static void Unsubscribe<T1>(string eventName, Action<T1> action)
        {
            var actions = GetActionsByName(eventName);
            if (actions == null)
                return;

            for (int i = 0; i < actions.Count; i++)
            {
                var invokeableAction = actions[i] as InvokableAction<T1>;

                if (invokeableAction.IsActionEqual(action))
                {
                    actions.RemoveAt(i);
                }
            }

            CheckForEventRemoval(eventName, actions);
        }

        /// <summary>
        /// Unubscribes from a global event with two parameters.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="action">The action to remove.</param>
        public static void Unsubscribe<T1, T2>(string eventName, Action<T1, T2> action)
        {
            var actions = GetActionsByName(eventName);
            if (actions == null)
                return;

            for (int i = 0; i < actions.Count; i++)
            {
                var invokeableAction = actions[i] as InvokableAction<T1, T2>;

                if (invokeableAction.IsActionEqual(action))
                {
                    actions.RemoveAt(i);
                }
            }

            CheckForEventRemoval(eventName, actions);
        }

        /// <summary>
        /// Unubscribes from a global event with three parameters.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="action">The action to remove.</param>
        public static void Unsubscribe<T1, T2, T3>(string eventName, Action<T1, T2, T3> action)
        {
            var actions = GetActionsByName(eventName);
            if (actions == null)
                return;

            for (int i = 0; i < actions.Count; i++)
            {
                var invokeableAction = actions[i] as InvokableAction<T1, T2, T3>;

                if (invokeableAction.IsActionEqual(action))
                {
                    actions.RemoveAt(i);
                }
            }

            CheckForEventRemoval(eventName, actions);
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

        internal static void CheckForEventRemoval(string eventName, List<InvokableActionBase> actions)
        {
            if (actions.Count == 0)
            {
                GlobalEventTable.Remove(eventName);
            }
        }

        internal static List<InvokableActionBase> GetActionsByName(string eventName)
        {
            if (GlobalEventTable.TryGetValue(eventName, out List<InvokableActionBase> actions))
                return actions;

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
        }
#endif
    }
}
