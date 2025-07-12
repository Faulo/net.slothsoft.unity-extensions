using System;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UObject = UnityEngine.Object;

namespace Slothsoft.UnityExtensions.Tests.PlayMode.ObjectPooling {
    [TestFixture(1)]
    [TestFixture(10)]
    [TestOf(typeof(GameObjectPool))]
    public class GameObjectPoolTests {

        readonly int capacity;

        public GameObjectPoolTests(int capacity) {
            this.capacity = capacity;
        }

        GameObject parent;
        GameObjectPool sut;

        [SetUp]
        public void SetUpSuT() {
            parent = new();

            sut = new(parent.transform, capacity);
        }

        [TearDown]
        public void TearDownSuT() {
            sut.Dispose();

            UObject.Destroy(parent);
        }

        [Test]
        public void GivenObjectPool_WhenRequestInstance_ThenReturn() {
            var actual = sut.RequestInstance();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.transform.parent, Is.SameAs(parent.transform));
            Assert.That(actual.activeSelf, Is.True);
        }

        [Test]
        public void GivenObjectPool_WhenReturnInstance_ThenDisable() {
            var actual = sut.RequestInstance();
            sut.ReturnInstance(actual);

            Assert.That(actual.activeSelf, Is.False);
        }

        [Test]
        public void GivenObjectPool_WhenRequestInstance_ThenRaiseOnInitiate() {
            var actual = Substitute.For<Action<GameObject>>();

            sut.onInstantiate += actual;

            var obj = sut.RequestInstance();

            actual.Received(1).Invoke(obj);
        }

        [Test]
        public void PooledObjectsShouldHaveBeenCreated() {
            for (int i = 0; i < capacity; i++) {
                sut.ReturnInstance(sut.RequestInstance());
            }

            Assert.That(parent.transform.childCount, Is.EqualTo(1));
        }

        [Test]
        public void PooledObjectsShouldStartOutInactive() {
            for (int i = 0; i < capacity; i++) {
                sut.ReturnInstance(sut.RequestInstance());
            }

            foreach (Transform child in parent.transform) {
                Assert.That(child.gameObject.activeSelf, Is.False);
            }
        }

        [Test]
        public void NoUpperLimitToObjects() {
            for (int i = 0; i < 2 * capacity; i++) {
                Assert.That(sut.RequestInstance(), Is.Not.Null);
            }

            Assert.That(parent.transform.childCount, Is.EqualTo(2 * capacity));
        }
    }
}