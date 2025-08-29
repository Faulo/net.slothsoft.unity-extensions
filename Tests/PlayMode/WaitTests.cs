using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Slothsoft.UnityExtensions.Tests.PlayMode {
    [TestFixture(TestOf = typeof(Wait))]
    sealed class WaitTests {
        static float errorMargin => Time.fixedDeltaTime;

        [UnityTest]
        public IEnumerator TestWaitForEndOfFrame() {
            if (Application.isBatchMode) {
                Assert.Inconclusive("Can't use WaitForEndOfFrame in batch mode.");
                yield break;
            }

            yield return Wait.forEndOfFrame;

            StartStopWatch();
            yield return Wait.forEndOfFrame;

            Assert.That(ElapsedTime(), Is.EqualTo(Time.fixedDeltaTime).Within(errorMargin));
        }

        [UnityTest]
        public IEnumerator TestWaitFixedUpdate() {
            yield return Wait.forFixedUpdate;

            StartStopWatch();
            yield return Wait.forFixedUpdate;

            Assert.That(ElapsedTime(), Is.EqualTo(Time.fixedDeltaTime).Within(errorMargin));
        }

        [TestCase(0.1f, ExpectedResult = null)]
        [TestCase(0.3f, ExpectedResult = null)]
        [UnityTest]
        public IEnumerator TestWaitForSeconds(float time) {
            yield return null;

            StartStopWatch();
            yield return Wait.forSeconds[time];

            Assert.That(ElapsedTime(), Is.EqualTo(time).Within(errorMargin));
        }

        [TestCase(0, 0.1f, ExpectedResult = null)]
        [TestCase(10, 0.3f, ExpectedResult = null)]
        [UnityTest]
        public IEnumerator TestWaitForSecondsRealtime(float timeScale, float time) {
            Time.timeScale = timeScale;

            yield return null;

            StartStopWatch(true);
            yield return Wait.forSecondsRealtime[time];

            Assert.That(ElapsedTime(true), Is.EqualTo(time).Within(errorMargin));
        }

        float start;
        void StartStopWatch(bool useRealTime = false) {
            start = useRealTime
                ? Time.unscaledTime
                : Time.time;
        }
        float ElapsedTime(bool useRealTime = false) {
            return useRealTime
                ? Time.unscaledTime - start
                : Time.time - start;
        }
    }
}