using System.Collections;
using System.Diagnostics;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Slothsoft.UnityExtensions.Tests.PlayMode {
    [TestFixture(TestOf = typeof(Wait))]
    sealed class WaitTests {
        float errorMargin => Time.fixedDeltaTime;
        [UnityTest]
        public IEnumerator TestWaitForEndOfFrame() {
            if (Application.isBatchMode) {
                Assert.Inconclusive("Can't use WaitForEndOfFrame in batch mode.");
                yield break;
            }

            var stopWatch = new Stopwatch();
            yield return Wait.forEndOfFrame;
            stopWatch.Start();
            yield return Wait.forEndOfFrame;
            stopWatch.Stop();
            Assert.AreEqual(stopWatch.Elapsed.TotalSeconds, Time.fixedDeltaTime, errorMargin);
        }
        [UnityTest]
        public IEnumerator TestWaitFixedUpdate() {
            var stopWatch = new Stopwatch();
            yield return Wait.forFixedUpdate;
            stopWatch.Start();
            yield return Wait.forFixedUpdate;
            stopWatch.Stop();
            Assert.AreEqual(stopWatch.Elapsed.TotalSeconds, Time.fixedDeltaTime, errorMargin);
        }
        [UnityTest]
        public IEnumerator TestWaitForSeconds() {
            var stopWatch = new Stopwatch();
            yield return null;
            stopWatch.Start();
            yield return Wait.forSeconds[0.1f];
            stopWatch.Stop();
            Assert.AreEqual(stopWatch.Elapsed.TotalSeconds, 0.1f, errorMargin);
        }
        [UnityTest]
        public IEnumerator TestWaitForSecondsRealtime() {
            var stopWatch = new Stopwatch();
            yield return null;
            stopWatch.Start();
            yield return Wait.forSecondsRealtime[0.1f];
            stopWatch.Stop();
            Assert.AreEqual(stopWatch.Elapsed.TotalSeconds, 0.1f, errorMargin);
        }
    }
}