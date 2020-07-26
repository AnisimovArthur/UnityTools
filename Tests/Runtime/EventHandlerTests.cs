using NUnit.Framework;

namespace UnityTools.Tests.Runtime
{
    internal class EventHandlerTests
    {
        private bool Result { get; set; }

        [Test]
        public void CheckForCorrectExecutingAndSubscribing()
        {
            Result = false;

            var firstEventName = "FirstEvent";
            var secondEventName = "FirstEvent";

            EventHandler.Subscribe<bool>(firstEventName, Change);

            EventHandler.Execute(firstEventName, true);
            EventHandler.Execute(secondEventName);
            Assert.AreEqual(Result, true);

            Result = false;

            EventHandler.Execute(firstEventName, false);
            Assert.AreEqual(Result, false);

            EventHandler.Unsubscribe<bool>(firstEventName, Change);
            Assert.AreEqual(Result, false);

            EventHandler.Execute(firstEventName, true);
            Assert.AreEqual(Result, false);
            EventHandler.Unsubscribe(firstEventName, Change);

        }

        private void Change(bool value)
        {
            Result = value;
        }

        private void Change()
        {
            Result = false;
        }
    }
}
