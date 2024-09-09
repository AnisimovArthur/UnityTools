using System.Collections;

using NUnit.Framework;

using UnityEngine;
using UnityEngine.TestTools;

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

            yield return new WaitForSeconds(WaitTime);
            Assert.AreEqual(Result, true);

            Scheduler.SkipFrame(() => Change(false));
            Assert.AreEqual(Result, true);
            yield return null;
            Assert.AreEqual(Result, false);
        }

        private void Change(bool value)
        {
            Result = value;
        }
    }
}
