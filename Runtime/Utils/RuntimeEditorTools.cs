#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Slothsoft.UnityExtensions {
    /// <summary>
    /// Inherit from this class to implement Editor tooling directly in the runtime assembly. When used, it will draw the default inspector and add a section "Editor Tools" beneath it.
    /// </summary>
    /// <example>
    /// <code>
    /// [UnityEditor.CustomEditor(typeof(MyComponent)), UnityEditor.CanEditMultipleObjects]
    /// class MyComponentEditor : RuntimeEditorTools<MyComponent> {
    ///     protected override void DrawEditorTools() {
    ///         DrawButton("Do stuff", () => component.Do("Stuff"));
    ///     }
    /// }
    /// </code>
    /// </example>
    public abstract class RuntimeEditorTools<T> : Editor where T : UnityEngine.Object {
        GUIStyle buttonStyle;
        GUIStyle foldoutStyle;
        GUIStyle objectStyle;
        readonly Dictionary<string, bool> foldoutFlags = new();

        /// <summary>
        /// The text on the topmost foldout button.
        /// </summary>
        protected virtual string label => $"<b>Editor Tools:</b> <i>{typeof(T)}</i>";

        /// <summary>
        /// The object to write editor tools for.
        /// </summary>
        protected new T target => base.target as T;

        [Obsolete("Use 'target' instead.")]
        protected T component => target;

        [Obsolete("Use 'target.gameObject' instead.")]
        protected GameObject gameObject => target is Component component
            ? component.gameObject
            : null;

        /// <summary>
        /// The current indendation level. Increase and decrease when drawing GUI stuff.
        /// </summary>
        protected int indentLevel {
            get => EditorGUI.indentLevel;
            set => EditorGUI.indentLevel = value;
        }
        public sealed override void OnInspectorGUI() {
            DrawDefaultInspector();

            if (!target) {
                return;
            }

            buttonStyle = new GUIStyle(EditorStyles.miniButton) { richText = true };
            foldoutStyle = new GUIStyle(EditorStyles.foldout) { richText = true };
            objectStyle = new GUIStyle(EditorStyles.objectField) { richText = true };

            EditorGUILayout.Space(EditorGUIUtility.singleLineHeight);

            if (DrawFoldout(label)) {
                indentLevel++;
                DrawEditorTools();
                indentLevel--;
            }
        }
        /// <summary>
        /// Draw a button with the label <paramref name="label"/>. If the button gets clicked, perform <paramref name="action"/>.
        /// </summary>
        protected void DrawButton(string label, Action action) {
            using (new GUILayout.HorizontalScope()) {
                GUILayout.Space(indentLevel * EditorGUIUtility.singleLineHeight / 2);
                if (GUILayout.Button(label, buttonStyle)) {
                    Undo.RecordObject(target, label);
                    action();
                    EditorUtility.SetDirty(target);
                    PrefabUtility.RecordPrefabInstancePropertyModifications(target);
                }
            }
        }
        /// <summary>
        /// Draw a button with the label <paramref name="label"/>. If the button gets clicked, start coroutine <paramref name="coroutine"/>.
        /// </summary>
        protected void DrawButton(string label, Func<IEnumerator> coroutine) {
            using (new GUILayout.HorizontalScope()) {
                GUILayout.Space(indentLevel * EditorGUIUtility.singleLineHeight / 2);
                if (GUILayout.Button(label, buttonStyle)) {
                    Unity.EditorCoroutines.Editor.EditorCoroutineUtility.StartCoroutine(Co_Button(label, coroutine), target);
                }
            }
        }
        IEnumerator Co_Button(string label, Func<IEnumerator> coroutine) {
            Undo.RecordObject(target, label);
            yield return coroutine();
            EditorUtility.SetDirty(target);
            PrefabUtility.RecordPrefabInstancePropertyModifications(target);
        }

        /// <summary>
        /// Draw a foldout with the label <paramref name="label"/>.
        /// </summary>
        protected bool DrawFoldout(string label, bool isOpenByDefault = true) {
            if (!foldoutFlags.ContainsKey(label)) {
                foldoutFlags[label] = isOpenByDefault;
            }

            foldoutFlags[label] = EditorGUILayout.Foldout(foldoutFlags[label], label, foldoutStyle);
            return foldoutFlags[label];
        }
        /// <summary>
        /// Draw an object picker with the label <paramref name="label"/>.
        /// </summary>
        protected TObj DrawObjectField<TObj>(string label, TObj obj, bool allowSceneObjects = false)
            where TObj : UnityEngine.Object {
            return EditorGUILayout.ObjectField(label, obj, typeof(TObj), allowSceneObjects) as TObj;
        }
        /// <summary>
        /// Draw an enum picker with the label <paramref name="label"/>.
        /// </summary>
        protected TEnum DrawEnumField<TEnum>(string label, TEnum value)
            where TEnum : Enum {
            return (TEnum)EditorGUILayout.EnumFlagsField(label, value, objectStyle);
        }
        protected abstract void DrawEditorTools();
    }
}
#endif