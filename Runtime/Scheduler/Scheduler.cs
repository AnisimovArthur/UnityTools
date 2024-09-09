using System;
using System.Collections.Generic;

using UnityEngine;

namespace UnityTools
{
    /// <summary>
    /// Tool for delayed event execution.
    /// </summary>
    public class Scheduler : MonoBehaviour
    {
        private static Scheduler instance;
        private static Scheduler Instance
        {
            get
            {
                if (instance == null)
                {
                    var singleton = new GameObject("[UnityTools] Scheduler").AddComponent<Scheduler>();
                    instance = singleton;
                    DontDestroyOnLoad(singleton);
                }

                return instance;
            }
        }

        private static List<ScheduledEvent> ScheduledEvents { get; set; } = new List<ScheduledEvent>();
        private static int ScheduledEventsCount { get; set; } = 0;

        /// <summary>
        /// Schedule a new event to occur after the specified delay.
        /// </summary>
        /// <param name="delay">Delay in seconds.</param>
        /// <param name="action">Action that occurs after the delay.</param>
        /// <returns>Event that scheduled.</returns>
        public static ScheduledEvent Schedule(float delay, Action action)
        {
            if (Instance == null)
                return null;

            if (action == null)
                return null;

            if (delay == 0)
            {
                action?.Invoke();
                return null;
            }

            var scheduledEvent = new ScheduledEvent(delay, Time.frameCount, action);
            ScheduledEvents.Add(scheduledEvent);
            ScheduledEventsCount++;
            return scheduledEvent;
        }

        /// <summary>
        /// Schedule a new event to occur in the next frame.
        /// </summary>
        /// <remarks>In Awake and first call OnEnable this will skip 2 frames.</remarks>
        /// <param name="action">Action that occurs in the next frame.</param>
        public static void SkipFrame(Action action)
        {
            Schedule(Mathf.Epsilon, action);
        }

        /// <summary>
        /// Cancels an event.
        /// </summary>
        /// <param name="scheduledEvent">Scheduled Event to cancel</param>
        public static void Cancel(ScheduledEvent scheduledEvent)
        {
            if (scheduledEvent == null)
                return;

            Remove(scheduledEvent);
        }

        /// <summary>
        /// Reset the system. Removes all scheduled events and destroys instance.
        /// </summary>
        public static void Clear()
        {
            if (ScheduledEvents != null)
                ScheduledEvents.Clear();

            if (instance != null)
            {
                Destroy(instance.gameObject);
            }

            instance = null;

            ScheduledEventsCount = 0;
        }

        internal static void Remove(ScheduledEvent scheduledEvent)
        {
            if (ScheduledEvents.Contains(scheduledEvent))
            {
                ScheduledEventsCount--;
                ScheduledEvents.Remove(scheduledEvent);
            }
            else
            {
                var errorMessage = $"[UnityTools.Scheduler] You are trying to remove a scheduled event, \n " +
                    $"but there is no such scheduled event (already removed? forgot to make it null?).";

                Delegate[] invocationList = scheduledEvent.Action.GetInvocationList();
                errorMessage += $"\n Invocation actions of the scheduled event:";

                if (invocationList.Length > 0)
                {
                    for (int i = 0; i < invocationList.Length; i++)
                    {
                        errorMessage += $"\n {invocationList[i].Target} - {invocationList[i].Method}";
                    }
                }
                else
                {
                    errorMessage += $"\n no invocation actions.";
                }

                Debug.LogError(errorMessage); ;
            }
        }

        private void Update()
        {
            int count = ScheduledEventsCount;
            for (int i = 0; i < count; i++)
            {
                ScheduledEvent scheduledEvent = ScheduledEvents[i];

                if (Time.frameCount == scheduledEvent.ScheduleFrame)
                {
                    continue;
                }

                if (scheduledEvent.EndTime <= Time.time)
                {
                    int prevCount = ScheduledEventsCount;
                    scheduledEvent.Invoke();

                    int diff = prevCount - ScheduledEventsCount;
                    count -= diff;
                    i = Mathf.Max(i - diff, 0);
                }
            }
        }

#if UNITY_2019_3_OR_NEWER
        /// <summary>
        /// Reset the static variables for domain reloading.
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void DomainReset()
        {
            if (ScheduledEvents != null)
                ScheduledEvents.Clear();

            instance = null;
            ScheduledEventsCount = 0;
        }
#endif
    }


    public class ScheduledEvent
    {
        public float EndTime { get; private set; }
        public float Delay { get; private set; }
        public int ScheduleFrame { get; private set; }

        internal Action Action { get; private set; }

        internal ScheduledEvent(float delay, int frame, Action action)
        {
            Delay = delay;
            EndTime = Time.time + Delay;
            ScheduleFrame = frame;
            Action = action;
        }

        internal void Invoke()
        {
            Action?.Invoke();
            Scheduler.Remove(this);
        }

        public void Cancel()
        {
            Scheduler.Cancel(this);
        }

        public float GetProgress()
        {
            return (Delay - GetRemainingTime()) / Delay;
        }

        public float GetRemainingTime()
        {
            float time = Time.time;

            if (time > EndTime)
            {
                return 0;
            }

            return EndTime - time;
        }
    }
}
