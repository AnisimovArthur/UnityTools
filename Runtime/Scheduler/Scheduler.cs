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
        /// <returns></returns>
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

            var scheduledEvent = new ScheduledEvent(delay, action);
            ScheduledEvents.Add(scheduledEvent);
            ScheduledEventsCount++;
            return scheduledEvent;
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

        internal static void Remove(ScheduledEvent scheduledEvent)
        {
            ScheduledEventsCount--;
            ScheduledEvents.Remove(scheduledEvent);
        }

        private void Update()
        {
            var count = ScheduledEventsCount;
            for (int i = 0; i < count; i++)
            {
                var scheduledEvent = ScheduledEvents[i];
                if (scheduledEvent.EndTime <= Time.time)
                {
                    var prevCount = ScheduledEventsCount;
                    scheduledEvent.Invoke();

                    var diff = prevCount - ScheduledEventsCount;
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
        internal Action Action { get; private set; }
        internal float EndTime { get; private set; }

        internal ScheduledEvent(float delay, Action action)
        {
            EndTime = Time.time + delay;
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
    }
}
