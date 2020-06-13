using System.Linq;
using System.Reflection;
using System.Collections.Generic;

using UnityEditor;

namespace UnityTools.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(UnityEngine.Object), true)]
    public class UnityToolsInspector : UnityEditor.Editor
    {
        private IEnumerable<MethodInfo> methods;

        private void OnEnable()
        {
            methods = ReflectionUtility.GetAllMethods(target,
                m => m.GetCustomAttributes(typeof(ButtonAttribute), true).Length > 0);
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            DrawButtons();
        }

        private void DrawButtons()
        {
            if (methods.Any())
            {
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("Actions");

                foreach (var method in methods)
                {
                    UnityToolsGUI.Button(serializedObject.targetObject, method);
                }
            }
        }
    }
}