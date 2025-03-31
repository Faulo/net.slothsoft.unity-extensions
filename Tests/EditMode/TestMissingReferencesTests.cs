using NUnit.Framework;
using UnityEngine;
using SuT = Slothsoft.UnityExtensions.Editor.Test;
using UnityObject = UnityEngine.Object;

namespace Slothsoft.UnityExtensions.Tests.EditMode {
    sealed class TestMissingReferencesTests {
        [Test]
        public void GivenObject_WhenIsValid_ThenReturnTrue() {
            var obj = ScriptableObject.CreateInstance<ScriptableObject>();

            bool actual = SuT.IsValidReference(obj);

            Assert.That(actual, Is.True);
        }

        [Test]
        public void GivenDestroyedObject_WhenIsValid_ThenReturnFalse() {
            var obj = ScriptableObject.CreateInstance<ScriptableObject>();

            UnityObject.DestroyImmediate(obj);

            bool actual = SuT.IsValidReference(obj);

            Assert.That(actual, Is.False);
        }
    }
}
