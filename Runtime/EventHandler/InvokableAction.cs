using System;

namespace UnityTools
{
    internal abstract class InvokableActionBase { }

    internal class InvokableAction : InvokableActionBase
    {
        private Action Action { get; set; }

        internal bool IsActionEqual(Action action) => Action == action;

        internal InvokableAction(Action action)
        {
            Action = action;
        }

        internal void Execute()
        {
            Action?.Invoke();
        }
    }

    internal class InvokableAction<T1> : InvokableActionBase
    {
        private Action<T1> Action { get; set; }

        internal bool IsActionEqual(Action<T1> action) => Action == action;

        internal InvokableAction(Action<T1> action)
        {
            Action = action;
        }

        internal void Execute(T1 arg1)
        {
            Action?.Invoke(arg1);
        }
    }

    internal class InvokableAction<T1, T2> : InvokableActionBase
    {
        private Action<T1, T2> Action { get; set; }

        internal bool IsActionEqual(Action<T1, T2> action) => Action == action;

        internal InvokableAction(Action<T1, T2> action)
        {
            Action = action;
        }

        internal void Execute(T1 arg1, T2 arg2)
        {
            Action?.Invoke(arg1, arg2);
        }
    }

    internal class InvokableAction<T1, T2, T3> : InvokableActionBase
    {
        private Action<T1, T2, T3> Action { get; set; }

        internal bool IsActionEqual(Action<T1, T2, T3> action) => Action == action;

        internal InvokableAction(Action<T1, T2, T3> action)
        {
            Action = action;
        }

        internal void Execute(T1 arg1, T2 arg2, T3 arg3)
        {
            Action?.Invoke(arg1, arg2, arg3);
        }
    }

    internal class InvokableAction<T1, T2, T3, T4> : InvokableActionBase
    {
        private Action<T1, T2, T3, T4> Action { get; set; }

        internal bool IsActionEqual(Action<T1, T2, T3, T4> action) => Action == action;

        internal InvokableAction(Action<T1, T2, T3, T4> action)
        {
            Action = action;
        }

        internal void Execute(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            Action?.Invoke(arg1, arg2, arg3, arg4);
        }
    }

    internal class InvokableAction<T1, T2, T3, T4, T5> : InvokableActionBase
    {
        private Action<T1, T2, T3, T4, T5> Action { get; set; }

        internal bool IsActionEqual(Action<T1, T2, T3, T4, T5> action) => Action == action;

        internal InvokableAction(Action<T1, T2, T3, T4, T5> action)
        {
            Action = action;
        }

        internal void Execute(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            Action?.Invoke(arg1, arg2, arg3, arg4, arg5);
        }
    }

    internal class InvokableAction<T1, T2, T3, T4, T5, T6> : InvokableActionBase
    {
        private Action<T1, T2, T3, T4, T5, T6> Action { get; set; }

        internal bool IsActionEqual(Action<T1, T2, T3, T4, T5, T6> action) => Action == action;

        internal InvokableAction(Action<T1, T2, T3, T4, T5, T6> action)
        {
            Action = action;
        }

        internal void Execute(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            Action?.Invoke(arg1, arg2, arg3, arg4, arg5, arg6);
        }
    }
}
