using System;

namespace UnityTools
{
    public static partial class EventHandler
    {
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
        /// Executes the global event with one parameter.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <param name="arg3">The third parameter.</param>
        /// <param name="arg4">The fourth parameter.</param>
        public static void Execute<T1, T2, T3, T4>(string eventName, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            var actions = GetActionsByName(eventName);
            if (actions == null)
                return;

            for (int i = actions.Count - 1; i >= 0; i--)
            {
                (actions[i] as InvokableAction<T1, T2, T3, T4>)?.Execute(arg1, arg2, arg3, arg4);
            }
        }

        /// <summary>
        /// Executes the global event with one parameter.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <param name="arg3">The third parameter.</param>
        /// <param name="arg4">The fourth parameter.</param>
        /// <param name="arg5">The fifth parameter.</param>
        public static void Execute<T1, T2, T3, T4, T5>(string eventName, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            var actions = GetActionsByName(eventName);
            if (actions == null)
                return;

            for (int i = actions.Count - 1; i >= 0; i--)
            {
                (actions[i] as InvokableAction<T1, T2, T3, T4, T5>)?.Execute(arg1, arg2, arg3, arg4, arg5);
            }
        }

        /// <summary>
        /// Executes the global event with one parameter.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <param name="arg3">The third parameter.</param>
        /// <param name="arg4">The fourth parameter.</param>
        /// <param name="arg5">The fifth parameter.</param>
        /// <param name="arg6">The sixth parameter.</param>
        public static void Execute<T1, T2, T3, T4, T5, T6>(string eventName, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            var actions = GetActionsByName(eventName);
            if (actions == null)
                return;

            for (int i = actions.Count - 1; i >= 0; i--)
            {
                (actions[i] as InvokableAction<T1, T2, T3, T4, T5, T6>)?.Execute(arg1, arg2, arg3, arg4, arg5, arg6);
            }
        }

        /// <summary>
        /// Executes the local object event with one parameter.
        /// </summary>
        /// <param name="obj">The object that the event is attached to.</param>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="arg1">The first parameter.</param>
        public static void Execute<T1>(object obj, string eventName, T1 arg1)
        {
            var actions = GetActionList(obj, eventName);
            if (actions == null)
                return;

            for (int i = actions.Count - 1; i >= 0; i--)
            {
                (actions[i] as InvokableAction<T1>)?.Execute(arg1);
            }
        }

        /// <summary>
        /// Executes the local object event with two parameter.
        /// </summary>
        /// <param name="obj">The object that the event is attached to.</param>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        public static void Execute<T1, T2>(object obj, string eventName, T1 arg1, T2 arg2)
        {
            var actions = GetActionList(obj, eventName);
            if (actions == null)
                return;

            for (int i = actions.Count - 1; i >= 0; i--)
            {
                (actions[i] as InvokableAction<T1, T2>)?.Execute(arg1, arg2);
            }
        }

        /// <summary>
        /// Executes the local object event with three parameter.
        /// </summary>
        /// <param name="obj">The object that the event is attached to.</param>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <param name="arg3">The third parameter.</param>
        public static void Execute<T1, T2, T3>(object obj, string eventName, T1 arg1, T2 arg2, T3 arg3)
        {
            var actions = GetActionList(obj, eventName);
            if (actions == null)
                return;

            for (int i = actions.Count - 1; i >= 0; i--)
            {
                (actions[i] as InvokableAction<T1, T2, T3>)?.Execute(arg1, arg2, arg3);
            }
        }

        /// <summary>
        /// Executes the local object event with four parameter.
        /// </summary>
        /// <param name="obj">The object that the event is attached to.</param>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <param name="arg3">The third parameter.</param>
        /// <param name="arg4">The fourth parameter.</param>
        public static void Execute<T1, T2, T3, T4>(object obj, string eventName, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            var actions = GetActionList(obj, eventName);
            if (actions == null)
                return;

            for (int i = actions.Count - 1; i >= 0; i--)
            {
                (actions[i] as InvokableAction<T1, T2, T3, T4>)?.Execute(arg1, arg2, arg3, arg4);
            }
        }

        /// <summary>
        /// Executes the local object event with five parameter.
        /// </summary>
        /// <param name="obj">The object that the event is attached to.</param>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <param name="arg3">The third parameter.</param>
        /// <param name="arg4">The fourth parameter.</param>
        /// <param name="arg5">The fifth parameter.</param>
        public static void Execute<T1, T2, T3, T4, T5>(object obj, string eventName, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            var actions = GetActionList(obj, eventName);
            if (actions == null)
                return;

            for (int i = actions.Count - 1; i >= 0; i--)
            {
                (actions[i] as InvokableAction<T1, T2, T3, T4, T5>)?.Execute(arg1, arg2, arg3, arg4, arg5);
            }
        }

        /// <summary>
        /// Executes the local object event with six parameter.
        /// </summary>
        /// <param name="obj">The object that the event is attached to.</param>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="arg1">The first parameter.</param>
        /// <param name="arg2">The second parameter.</param>
        /// <param name="arg3">The third parameter.</param>
        /// <param name="arg4">The fourth parameter.</param>
        /// <param name="arg5">The fifth parameter.</param>
        /// <param name="arg6">The sixth parameter.</param>
        public static void Execute<T1, T2, T3, T4, T5, T6>(object obj, string eventName, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            var actions = GetActionList(obj, eventName);
            if (actions == null)
                return;

            for (int i = actions.Count - 1; i >= 0; i--)
            {
                (actions[i] as InvokableAction<T1, T2, T3, T4, T5, T6>)?.Execute(arg1, arg2, arg3, arg4, arg5, arg6);
            }
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
        /// Subscribes to a global event with four parameters.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="action">The action to call when the event executes.</param>
        public static void Subscribe<T1, T2, T3, T4>(string eventName, Action<T1, T2, T3, T4> action)
        {
            SubscribeInternal(eventName, new InvokableAction<T1, T2, T3, T4>(action));
        }

        /// <summary>
        /// Subscribes to a global event with five parameters.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="action">The action to call when the event executes.</param>
        public static void Subscribe<T1, T2, T3, T4, T5>(string eventName, Action<T1, T2, T3, T4, T5> action)
        {
            SubscribeInternal(eventName, new InvokableAction<T1, T2, T3, T4, T5>(action));
        }

        /// <summary>
        /// Subscribes to a global event with six parameters.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="action">The action to call when the event executes.</param>
        public static void Subscribe<T1, T2, T3, T4, T5, T6>(string eventName, Action<T1, T2, T3, T4, T5, T6> action)
        {
            SubscribeInternal(eventName, new InvokableAction<T1, T2, T3, T4, T5, T6>(action));
        }

        /// <summary>
        /// Subscribes to a local object event with one parameter.
        /// </summary>
        /// <param name="obj">The target object.</param>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="action">The action to call when the event executes.</param>
        public static void Subscribe<T1>(object obj, string eventName, Action<T1> action)
        {
            SubscribeInternal(obj, eventName, new InvokableAction<T1>(action));
        }

        /// <summary>
        /// Subscribes to a local object event with two parameters.
        /// </summary>
        /// <param name="obj">The target object.</param>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="action">The action to call when the event executes.</param>
        public static void Subscribe<T1, T2>(object obj, string eventName, Action<T1, T2> action)
        {
            SubscribeInternal(obj, eventName, new InvokableAction<T1, T2>(action));
        }

        /// <summary>
        /// Subscribes to a local object event with three parameters.
        /// </summary>
        /// <param name="obj">The target object.</param>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="action">The action to call when the event executes.</param>
        public static void Subscribe<T1, T2, T3>(object obj, string eventName, Action<T1, T2, T3> action)
        {
            SubscribeInternal(obj, eventName, new InvokableAction<T1, T2, T3>(action));
        }

        /// <summary>
        /// Subscribes to a local object event with four parameters.
        /// </summary>
        /// <param name="obj">The target object.</param>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="action">The action to call when the event executes.</param>
        public static void Subscribe<T1, T2, T3, T4>(object obj, string eventName, Action<T1, T2, T3, T4> action)
        {
            SubscribeInternal(obj, eventName, new InvokableAction<T1, T2, T3, T4>(action));
        }

        /// <summary>
        /// Subscribes to a local object event with five parameters.
        /// </summary>
        /// <param name="obj">The target object.</param>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="action">The action to call when the event executes.</param>
        public static void Subscribe<T1, T2, T3, T4, T5>(object obj, string eventName, Action<T1, T2, T3, T4, T5> action)
        {
            SubscribeInternal(obj, eventName, new InvokableAction<T1, T2, T3, T4, T5>(action));
        }

        /// <summary>
        /// Subscribes to a local object event with six parameters.
        /// </summary>
        /// <param name="obj">The target object.</param>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="action">The action to call when the event executes.</param>
        public static void Subscribe<T1, T2, T3, T4, T5, T6>(object obj, string eventName, Action<T1, T2, T3, T4, T5, T6> action)
        {
            SubscribeInternal(obj, eventName, new InvokableAction<T1, T2, T3, T4, T5, T6>(action));
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
                    break;
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
                    break;
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
                    break;
                }
            }

            CheckForEventRemoval(eventName, actions);
        }

        /// <summary>
        /// Unubscribes from a global event with three parameters.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="action">The action to remove.</param>
        public static void Unsubscribe<T1, T2, T3, T4>(string eventName, Action<T1, T2, T3, T4> action)
        {
            var actions = GetActionsByName(eventName);
            if (actions == null)
                return;

            for (int i = 0; i < actions.Count; i++)
            {
                var invokeableAction = actions[i] as InvokableAction<T1, T2, T3, T4>;

                if (invokeableAction.IsActionEqual(action))
                {
                    actions.RemoveAt(i);
                    break;
                }
            }

            CheckForEventRemoval(eventName, actions);
        }

        /// <summary>
        /// Unubscribes from a global event with three parameters.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="action">The action to remove.</param>
        public static void Unsubscribe<T1, T2, T3, T4, T5>(string eventName, Action<T1, T2, T3, T4, T5> action)
        {
            var actions = GetActionsByName(eventName);
            if (actions == null)
                return;

            for (int i = 0; i < actions.Count; i++)
            {
                var invokeableAction = actions[i] as InvokableAction<T1, T2, T3, T4, T5>;

                if (invokeableAction.IsActionEqual(action))
                {
                    actions.RemoveAt(i);
                    break;
                }
            }

            CheckForEventRemoval(eventName, actions);
        }

        /// <summary>
        /// Unubscribes from a global event with three parameters.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="action">The action to remove.</param>
        public static void Unsubscribe<T1, T2, T3, T4, T5, T6>(string eventName, Action<T1, T2, T3, T4, T5, T6> action)
        {
            var actions = GetActionsByName(eventName);
            if (actions == null)
                return;

            for (int i = 0; i < actions.Count; i++)
            {
                var invokeableAction = actions[i] as InvokableAction<T1, T2, T3, T4, T5, T6>;

                if (invokeableAction.IsActionEqual(action))
                {
                    actions.RemoveAt(i);
                    break;
                }
            }

            CheckForEventRemoval(eventName, actions);
        }

        /// <summary>
        /// Unubscribes from a local object event with one parameter.
        /// </summary>
        /// <param name="obj">The object that the event is attached to.</param>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="action">The action to remove.</param>
        public static void Unsubscribe<T1>(object obj, string eventName, Action<T1> action)
        {
            var actions = GetActionList(obj, eventName);
            if (actions == null)
                return;

            for (int i = 0; i < actions.Count; i++)
            {
                var invokeableAction = (actions[i] as InvokableAction<T1>);
                if (invokeableAction.IsActionEqual(action))
                {
                    actions.RemoveAt(i);
                    break;
                }
            }

            CheckForEventRemoval(obj, eventName, actions);
        }

        /// <summary>
        /// Unubscribes from a local object event with two parameters.
        /// </summary>
        /// <param name="obj">The object that the event is attached to.</param>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="action">The action to remove.</param>
        public static void Unsubscribe<T1, T2>(object obj, string eventName, Action<T1, T2> action)
        {
            var actions = GetActionList(obj, eventName);
            if (actions == null)
                return;

            for (int i = 0; i < actions.Count; i++)
            {
                var invokeableAction = (actions[i] as InvokableAction<T1, T2>);
                if (invokeableAction.IsActionEqual(action))
                {
                    actions.RemoveAt(i);
                    break;
                }
            }

            CheckForEventRemoval(obj, eventName, actions);
        }

        /// <summary>
        /// Unubscribes from a local object event with three parameters.
        /// </summary>
        /// <param name="obj">The object that the event is attached to.</param>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="action">The action to remove.</param>
        public static void Unsubscribe<T1, T2, T3>(object obj, string eventName, Action<T1, T2, T3> action)
        {
            var actions = GetActionList(obj, eventName);
            if (actions == null)
                return;

            for (int i = 0; i < actions.Count; i++)
            {
                var invokeableAction = (actions[i] as InvokableAction<T1, T2, T3>);
                if (invokeableAction.IsActionEqual(action))
                {
                    actions.RemoveAt(i);
                    break;
                }
            }

            CheckForEventRemoval(obj, eventName, actions);
        }

        /// <summary>
        /// Unubscribes from a local object event with four parameters.
        /// </summary>
        /// <param name="obj">The object that the event is attached to.</param>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="action">The action to remove.</param>
        public static void Unsubscribe<T1, T2, T3, T4>(object obj, string eventName, Action<T1, T2, T3, T4> action)
        {
            var actions = GetActionList(obj, eventName);
            if (actions == null)
                return;

            for (int i = 0; i < actions.Count; i++)
            {
                var invokeableAction = (actions[i] as InvokableAction<T1, T2, T3, T4>);
                if (invokeableAction.IsActionEqual(action))
                {
                    actions.RemoveAt(i);
                    break;
                }
            }

            CheckForEventRemoval(obj, eventName, actions);
        }

        /// <summary>
        /// Unubscribes from a local object event with five parameters.
        /// </summary>
        /// <param name="obj">The object that the event is attached to.</param>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="action">The action to remove.</param>
        public static void Unsubscribe<T1, T2, T3, T4, T5>(object obj, string eventName, Action<T1, T2, T3, T4, T5> action)
        {
            var actions = GetActionList(obj, eventName);
            if (actions == null)
                return;

            for (int i = 0; i < actions.Count; i++)
            {
                var invokeableAction = (actions[i] as InvokableAction<T1, T2, T3, T4, T5>);
                if (invokeableAction.IsActionEqual(action))
                {
                    actions.RemoveAt(i);
                    break;
                }
            }

            CheckForEventRemoval(obj, eventName, actions);
        }

        /// <summary>
        /// Unubscribes from a local object event with six parameters.
        /// </summary>
        /// <param name="obj">The object that the event is attached to.</param>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="action">The action to remove.</param>
        public static void Unsubscribe<T1, T2, T3, T4, T5, T6>(object obj, string eventName, Action<T1, T2, T3, T4, T5, T6> action)
        {
            var actions = GetActionList(obj, eventName);
            if (actions == null)
                return;

            for (int i = 0; i < actions.Count; i++)
            {
                var invokeableAction = (actions[i] as InvokableAction<T1, T2, T3, T4, T5, T6>);
                if (invokeableAction.IsActionEqual(action))
                {
                    actions.RemoveAt(i);
                    break;
                }
            }

            CheckForEventRemoval(obj, eventName, actions);
        }
    }
}
