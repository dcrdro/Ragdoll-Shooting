using Core.Scriptable;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(ScriptableMapperBase<,>), true)]
    public class MapperEditor : UnityEditor.Editor
    {
        private const int labelWidth = 100;
    
        private SerializedProperty keys;
        private SerializedProperty values;

        private int mapSize;

        private GUIStyle headerStyle;
    
        void OnEnable()
        {
            keys = serializedObject.FindProperty("mapperKeys");
            values = serializedObject.FindProperty("mapperValues");
            mapSize = keys.arraySize;
        
            headerStyle = new GUIStyle();
            headerStyle.fontSize = 18;
            headerStyle.fontStyle = FontStyle.Bold;
            headerStyle.alignment = TextAnchor.MiddleCenter;
        }
    
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.LabelField("Mapper", headerStyle);
            EditorGUILayout.Space(20);

            EditorGUILayout.BeginHorizontal(); 
            {
                mapSize = EditorGUILayout.IntField("Size", mapSize);
                if (GUILayout.Button("+")) mapSize++;
                if (GUILayout.Button("-")) mapSize--;
            }
            EditorGUILayout.EndHorizontal();
        
            mapSize = Mathf.Clamp(mapSize, 0, 100);
            keys.arraySize = mapSize;
            values.arraySize = mapSize;

            float savedLabelWidth = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = labelWidth;
            EditorGUI.indentLevel++;
            for (int i = 0; i < mapSize; i++)
            {
                EditorGUILayout.BeginHorizontal();
                {
                    EditorGUILayout.PropertyField(keys.GetArrayElementAtIndex(i), new GUIContent("Key"));
                    EditorGUILayout.PropertyField(values.GetArrayElementAtIndex(i), new GUIContent("Value"));
                }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUI.indentLevel--;
            EditorGUIUtility.labelWidth = savedLabelWidth;

            serializedObject.ApplyModifiedProperties();
        }
    }
}
