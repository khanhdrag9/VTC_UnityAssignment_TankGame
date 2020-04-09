using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(EnemyPattern))]
public class EnemyPatternEditor : Editor
{
    EnemyPattern enemyPattern;

    private GUIStyle m_DefaultRemoveButtonStyle;
    public GUIStyle DefaultRemoveButtonStyle
    {
        get
        {
            if (m_DefaultRemoveButtonStyle == null)
            {
                m_DefaultRemoveButtonStyle = new GUIStyle();
                m_DefaultRemoveButtonStyle.fixedWidth = 30;
                m_DefaultRemoveButtonStyle.fixedHeight = 20;
                m_DefaultRemoveButtonStyle.imagePosition = ImagePosition.ImageOnly;
                m_DefaultRemoveButtonStyle.alignment = TextAnchor.MiddleCenter;
            }

            return m_DefaultRemoveButtonStyle;
        }
    }

    private GUIStyle m_DefaultAddButtonStyle;
    public GUIStyle DefaultAddButtonStyle
    {
        get
        {
            if (m_DefaultAddButtonStyle == null)
            {
                m_DefaultAddButtonStyle = new GUIStyle();
                m_DefaultAddButtonStyle.fixedWidth = 30;
                m_DefaultAddButtonStyle.fixedHeight = 16;
            }

            return m_DefaultAddButtonStyle;
        }
    }

    public override void OnInspectorGUI()
    {
        enemyPattern = (EnemyPattern)target;

        if (enemyPattern.points == null)
        {
            enemyPattern.points = new List<Vector2>();
        }

        if (enemyPattern.points.Count == 0)
        {
            enemyPattern.points.Add(Vector2.zero);
        }

        GUI.color = Color.white;
        this.DrawElements();
    }
    private void DrawElements()
    {
        GUILayout.Space(5);
        SerializedProperty listProperty = serializedObject.FindProperty("points");

        if (listProperty == null)
        {
            return;
        }

        float containerElementHeight = 22;
        float containerHeight = listProperty.arraySize * containerElementHeight;

        bool isObservedComponentsEmpty = this.enemyPattern.points.FindAll(item => item != null).Count == 0;
        Rect containerRect = EditorGUILayout.GetControlRect(false, containerHeight);
        containerRect.yMin -= 3;
        containerRect.yMax -= 2;

        for (int i = 0; i < listProperty.arraySize; ++i)
        {
            Rect elementRect = new Rect(containerRect.xMin, containerRect.yMin + containerElementHeight * i, containerRect.width, containerElementHeight);
            Rect propertyPosition = new Rect(elementRect.xMin, elementRect.yMin + 3, elementRect.width - 5, 19);

            EditorGUI.PropertyField(propertyPosition, listProperty.GetArrayElementAtIndex(i));


            Rect removeButtonRect = new Rect(elementRect.xMax - DefaultRemoveButtonStyle.fixedWidth,
                                             elementRect.yMin + 2,
                                             DefaultRemoveButtonStyle.fixedWidth,
                                             DefaultRemoveButtonStyle.fixedHeight);
            GUI.enabled = listProperty.arraySize > 1;
            if (GUI.Button(removeButtonRect, new GUIContent("-")))
            {
                listProperty.DeleteArrayElementAtIndex(i);
            }
            GUI.enabled = true;
        }

        Rect controlRect = EditorGUILayout.GetControlRect(false, DefaultAddButtonStyle.fixedHeight - 5);
        controlRect.yMin -= 5;
        controlRect.yMax -= 5;

        Rect addButtonRect = new Rect(controlRect.xMax - DefaultAddButtonStyle.fixedWidth,
                                      controlRect.yMin,
                                      DefaultAddButtonStyle.fixedWidth,
                                      DefaultAddButtonStyle.fixedHeight);
        if (GUI.Button(addButtonRect, "+"))
        {
            listProperty.InsertArrayElementAtIndex(Mathf.Max(0, listProperty.arraySize - 1));
        }

        serializedObject.ApplyModifiedProperties();
    }

    public void OnSceneGUI()
    {
        enemyPattern = target as EnemyPattern;

        for (int i = 0; i < enemyPattern.points.Count; i++)
        {
            enemyPattern.points[i] = Handles.PositionHandle(enemyPattern.points[i], Quaternion.identity);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
