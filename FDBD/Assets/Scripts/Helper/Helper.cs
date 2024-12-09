using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ư�� ������Ʈ�� ����� �׷��ִ� Ŭ����
/// ���� ��ġ�� ���� �޽ð� ���� ������Ʈ�� ��ġ�� ������ �� �������
/// </summary>
public class DrawGizmo : MonoBehaviour
{
#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawCube(new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), new Vector3(2f, 0.1f, 2f));
    }
#endif
}
