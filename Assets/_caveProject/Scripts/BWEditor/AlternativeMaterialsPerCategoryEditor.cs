#if UNITY_EDITOR
using Buildwise.BIM;
using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AlternativeMaterialsPerCategorySO))]
public class AlternativeMaterialsEditor : Editor
{
    private SerializedProperty _categories;
    private SerializedProperty _materials;

    private GUIContent plusButton;
    private GUIContent minusButton;

    private void OnEnable()
    {
        plusButton = new GUIContent();
        plusButton.text = "+";

        minusButton = new GUIContent();
        minusButton.text = "-";

        _categories = serializedObject.FindProperty("Categories");
        _materials = serializedObject.FindProperty("Materials");

    }

    public override void OnInspectorGUI()
    {
        serializedObject.UpdateIfRequiredOrScript();

        PlaceNumberOfCategoriesButton();

        float availableHorizontalSpace = EditorGUIUtility.currentViewWidth;
        int verticalSectionsCount = 0;
        EditorGUILayout.BeginHorizontal();
        for (int i = 0; i < _categories.arraySize; i++)
        {
            if (verticalSectionsCount != 0 && verticalSectionsCount % 2 == 0)
            {
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
            }

            EditorGUILayout.BeginVertical();
            EditorGUILayout.BeginHorizontal();
            _categories.GetArrayElementAtIndex(i).enumValueIndex = (int)(BIMCategory)EditorGUILayout.EnumPopup((BIMCategory)Enum.GetValues(typeof(BIMCategory)).GetValue(_categories.GetArrayElementAtIndex(i).enumValueIndex), GUILayout.MaxWidth(availableHorizontalSpace / 6));

            SerializedProperty mats = _materials.GetArrayElementAtIndex(i).FindPropertyRelative("Items");

            EditorGUILayout.BeginHorizontal();
            GUIStyle style = new GUIStyle();
            style.fontStyle = FontStyle.Normal;
            style.wordWrap = true;
            style.normal.textColor = new Color(190, 190, 190);
            style.alignment = TextAnchor.MiddleCenter;
            EditorGUILayout.LabelField("Nb materials", style, GUILayout.MaxWidth(availableHorizontalSpace / 6));
            EditorGUILayout.IntField("", mats.arraySize, GUILayout.MaxWidth(availableHorizontalSpace / 20));
            if (GUILayout.Button(plusButton, GUILayout.MaxWidth(availableHorizontalSpace / 20)))
            {
                mats.InsertArrayElementAtIndex(mats.arraySize);
                mats.GetArrayElementAtIndex(mats.arraySize - 1).objectReferenceValue = null;
            }
            if (GUILayout.Button(minusButton, GUILayout.MaxWidth(availableHorizontalSpace / 20)))
            {
                if (mats.arraySize > 0)
                {
                    mats.DeleteArrayElementAtIndex(mats.arraySize - 1);
                }
            }
            GUILayout.FlexibleSpace();
            serializedObject.ApplyModifiedProperties();
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndHorizontal();


            EditorGUILayout.BeginVertical();
            for (int j = 0; j < mats.arraySize; j++)
            {
                EditorGUILayout.ObjectField(mats.GetArrayElementAtIndex(j), GUIContent.none, GUILayout.MaxWidth(availableHorizontalSpace / 2));
            }
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndVertical();

            verticalSectionsCount++;
        }
        EditorGUILayout.EndHorizontal();

        serializedObject.ApplyModifiedProperties();
        EditorUtility.SetDirty(serializedObject.targetObject);
    }

    private void PlaceNumberOfCategoriesButton()
    {
        EditorGUILayout.BeginHorizontal();

        GUIContent label = new GUIContent();
        GUIStyle labelStyle = GetLabelStyle();
        label.text = "Number of categories";
        label.tooltip = "This is the number of categories for which alternative materials are defined";
        EditorGUILayout.LabelField(label, labelStyle);

        EditorGUILayout.IntField("", _categories.arraySize);

        if (GUILayout.Button(plusButton))
        {
            _categories.InsertArrayElementAtIndex(_categories.arraySize);
            _materials.InsertArrayElementAtIndex(_materials.arraySize);
        }
        if (GUILayout.Button(minusButton))
        {
            if (_categories.arraySize > 0)
            {
                _categories.DeleteArrayElementAtIndex(_categories.arraySize - 1);
                _materials.DeleteArrayElementAtIndex(_materials.arraySize - 1);
            }
        }
        EditorGUILayout.EndHorizontal();
    }

    private GUIStyle GetLabelStyle()
    {
        GUIStyle labelStyle = new GUIStyle();
        labelStyle.wordWrap = true;
        labelStyle.stretchWidth = true;
        labelStyle.alignment = TextAnchor.UpperLeft;
        labelStyle.normal.textColor = Color.white;

        return labelStyle;
    }
}
#endif