using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestSuite
    {
        // A Test behaves as an ordinary method
        [Test]
        public void playerDirectionInitialize()
        {
            // Use the Assert class to test conditions
            PlayerController controller = new PlayerController();
         
            // test no input yet and right facing controller initialization
            Assert.AreEqual(true, controller.rightfacing);

        }
        [Test]
        public void triggerInitialization()
        {
            PlayerController controller = new PlayerController();

            Assert.AreEqual(false, controller.LTActive);
            Assert.AreEqual(false, controller.RTActive);
        }
        [Test]
        public void levelInitializerTest()
        {
            // Use the Assert class to test conditions
            StateManager testState = new StateManager();

            Assert.AreEqual(1, testState.currLevel);

        }


        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
