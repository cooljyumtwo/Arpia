using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DrawGizmo : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        // Gizmo ���� ����
        Gizmos.color = Color.white;

        // ������Ʈ�� ��ġ�� transform ������ �ؽ�Ʈ�� ǥ���մϴ�.
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.white;
        Handles.Label(transform.position + Vector3.up * 0.7f, $"Position: {transform.position}", style);

        // ������Ʈ�� ��ġ�� �߽����� �ڽ� ����� Gizmo�� �׸��ϴ�.
        Gizmos.DrawWireCube(transform.position, new Vector3(1, 2, 1));
    }
}