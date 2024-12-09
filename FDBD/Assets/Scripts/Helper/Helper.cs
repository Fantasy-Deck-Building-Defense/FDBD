using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 특정 오브젝트의 기즈모를 그려주는 클래스
/// 스폰 위치와 같이 메시가 없는 오브젝트의 위치를 보여줄 때 사용하자
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
