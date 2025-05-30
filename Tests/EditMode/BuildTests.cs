using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Slothsoft.UnityExtensions.Editor;

namespace Slothsoft.UnityExtensions.Tests.EditMode {
    [TestFixture(TestOf = typeof(Build))]
    sealed class BuildTests {
        IEnumerable<string> projectFiles => new[] {
            AssemblyInfo.NAMESPACE_RUNTIME,
            AssemblyInfo.NAMESPACE_EDITOR,
            AssemblyInfo.NAMESPACE_TESTS_PLAYMODE,
            AssemblyInfo.NAMESPACE_TESTS_EDITMODE
        }.Select(ns => ns + ".csproj");

        [Test]
        public void TestBuildSolution() {
            foreach (string file in projectFiles) {
                File.Delete(file);
            }

            Build.Solution();

            foreach (string file in projectFiles) {
                FileAssert.Exists(file);
            }
        }

        [Test]
        public void TestCSProjDoesNotUseLatestVersion() {
            Build.Solution();

            foreach (string file in projectFiles) {
                string contents = File.ReadAllText(file);
                StringAssert.DoesNotContain(contents, "<LangVersion>latest</LangVersion>");
            }
        }

        [Test]
        public void TestGetCSharpVersion() {
            Assert.AreEqual(new Version(9, 0), Build.GetCSharpVersion());
        }
    }
}