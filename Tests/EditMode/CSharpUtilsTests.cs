using NUnit.Framework;
using Slothsoft.UnityExtensions.Editor;
using UnityEditor;
using UnityEditorInternal;

namespace Slothsoft.UnityExtensions.Tests.EditMode {
    sealed class CSharpUtilsTests {
        [TestCase("Editor/", "CSharpFileFixer/CSharpModificationProcessor.cs", "Slothsoft.UnityExtensions.Editor.asmdef")]
        [TestCase("Runtime/", "AssemblyInfo.cs", "Slothsoft.UnityExtensions.asmdef")]
        [TestCase("Tests/EditMode/", "CSharpUtilsTests.cs", "Slothsoft.UnityExtensions.Tests.EditMode.asmdef")]
        [TestCase("Tests/PlayMode/", "AssemblyInfo.cs", "Slothsoft.UnityExtensions.Tests.PlayMode.asmdef")]
        [TestCase("", "package.json", "")]
        [TestCase("", "FileThatDoesNotExist.txt", "")]
        public void TestGetNamespace(string assetDirectory, string filePath, string assemblyPath) {
            string pathBase = $"Packages/{AssemblyInfo.PACKAGE_ID}/{assetDirectory}";

            AssemblyDefinitionAsset expectedAssembly = default;
            if (!string.IsNullOrEmpty(assemblyPath)) {
                expectedAssembly = AssetDatabase.LoadAssetAtPath<AssemblyDefinitionAsset>(pathBase + assemblyPath);
                Assert.IsTrue(expectedAssembly, $"Failed to find expected assembly '{pathBase + assemblyPath}'!");
            }

            var actualAssembly = CSharpUtils.GetAssembly(pathBase + filePath);

            Assert.AreEqual(expectedAssembly, actualAssembly);
        }
    }
}