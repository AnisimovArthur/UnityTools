using System.Collections;

using UnityEngine;
using UnityEngine.TestTools;

using NUnit.Framework;

namespace UnityTools.Tests.Runtime
{
    internal class SchedulerTests
    {
        const float ScheduleTime = 0.001f;
        const float WaitTime = 0.0015f;

        private bool Result { get; set; }

        [UnityTest]
        public IEnumerator CheckForCorrectScheduling()
        {
            Result = true;

            Scheduler.Schedule(ScheduleTime, () => Change(true));
            yield return new WaitForSeconds(WaitTime);
            Assert.AreEqual(Result, true);

            var schedule = Scheduler.Schedule(ScheduleTime, () => Change(false));
            schedule.Cancel();
            Scheduler.Cancel(schedule);
            yield return new WaitForSeconds(WaitTime);
            Assert.AreEqual(Result, true);
        }

        private void Change(bool value)
        {
            Result = value;
        }
    }
}
