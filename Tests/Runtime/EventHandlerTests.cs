using UnityEngine;

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

            var eventName = "EventName";

            EventHandler.Subscribe<bool>(eventName, Change);

            EventHandler.Execute(eventName, true);
            EventHandler.Execute(eventName);
            Assert.AreEqual(Result, true);

            Result = false;

            EventHandler.Execute(eventName, false);
            Assert.AreEqual(Result, false);

            EventHandler.Unsubscribe<bool>(eventName, Change);
            Assert.AreEqual(Result, false);

            EventHandler.Execute(eventName, true);
            Assert.AreEqual(Result, false);
            EventHandler.Unsubscribe(eventName, Change);

            CheckForCorrectExecutingAndSubscribingLocal();
        }

        public void CheckForCorrectExecutingAndSubscribingLocal()
        {
            Result = true;

            var eventName = "EventName";
            var gameObject = new GameObject();
            var gameObject2 = new GameObject();

            EventHandler.Subscribe(gameObject2, eventName, Change);
            EventHandler.Execute(gameObject, eventName);
            Assert.AreEqual(Result, true);
            EventHandler.Execute(gameObject2, eventName);
            Assert.AreEqual(Result, false);

            Result = true;
            EventHandler.Unsubscribe(gameObject2, eventName, Change);
            EventHandler.Execute(gameObject2, eventName);
            Assert.AreEqual(Result, true);

            EventHandler.Subscribe<bool>(gameObject, eventName, Change);
            EventHandler.Execute(gameObject2, eventName, false);
            Assert.AreEqual(Result, true);
            EventHandler.Execute(gameObject, eventName, false);
            Assert.AreEqual(Result, false);
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
