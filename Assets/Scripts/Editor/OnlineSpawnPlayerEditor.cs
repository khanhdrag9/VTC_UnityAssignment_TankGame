using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(OnlineSpawnPlayer))]
public class OnlineSpawnPlayerEditor : Editor
{
    private void OnSceneGUI()
    {
        var osp = target as OnlineSpawnPlayer;
        if (osp.positions == null)
        {
            osp.positions = new List<Vector2>();
            osp.positions.Add(Vector2.zero);
        }

        for (int i = 0; i < osp.positions.Count; i++)
        {
            osp.positions[i] = Handles.PositionHandle(osp.positions[i], Quaternion.identity);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
