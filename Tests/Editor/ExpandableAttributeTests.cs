﻿using NUnit.Framework;
using Slothsoft.UnityExtensions;
using UnityEngine;

public class ExpandableAttributeTests {
    interface IOne {
    }
    interface ITwo {
    }
    class A : MonoBehaviour, IOne, ITwo {
    }
    class B : MonoBehaviour {
    }
    [Test]
    public void TestClassImplementsInterfaces() {
        var attribute = new ExpandableAttribute(typeof(IOne), typeof(ITwo));
        var obj = new GameObject().AddComponent<A>();

        Assert.IsTrue(attribute.ValidateType(obj), $"{typeof(A)} must pass validation.");
    }
    [Test]
    public void TestClassDoesNotImplementInterfaces() {
        var attribute = new ExpandableAttribute(typeof(IOne), typeof(ITwo));
        var obj = new GameObject().AddComponent<B>();

        Assert.IsFalse(attribute.ValidateType(obj), $"{typeof(B)} must not pass validation.");
    }
}
