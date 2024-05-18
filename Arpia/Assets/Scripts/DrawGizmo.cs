using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DrawGizmo : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        // Gizmo 색상 설정
        Gizmos.color = Color.white;

        // 오브젝트의 위치에 구체 모양의 Gizmo를 그립니다.
        Gizmos.DrawSphere(transform.position, 0.5f);

        // 오브젝트의 위치에 transform 정보를 텍스트로 표시합니다.
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.white;
        Handles.Label(transform.position + Vector3.up * 0.7f, $"Position: {transform.position}", style);

        // 오브젝트의 위치에서 아래쪽으로 선을 그립니다.
        Gizmos.DrawLine(transform.position, transform.position - Vector3.up * 2);

        // 오브젝트의 위치를 중심으로 박스 모양의 Gizmo를 그립니다.
        Gizmos.DrawWireCube(transform.position, new Vector3(1, 2, 1));
    }
}