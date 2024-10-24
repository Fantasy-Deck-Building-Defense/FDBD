using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // 유닛 기본 정보
    string unitName;        // 유닛명
    float range;            // 유닛 사거리
    int money;              // 유닛가격
    int mana;               // 유닛 사용시 드는 마나
    int count;              // -1 is infinity
    string explain;         //(설명)

    // 유닛 타입
    //bool 공격유닛인가?;
    //bool 자원유닛인가?;
    //bool 효과유닛인가?;

    // 유닛 공격 타입
    eAttackType attackType;

    private List<Collider> Enemys = new List<Collider>();

    // 공통 함수
    //void Move(Vector3 pos)


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemys.Add(other);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Collider closestObj = null;
            float closestDis = Mathf.Infinity;

            // 현재 오브젝트의 위치
            Vector3 currentPos = transform.position;

            foreach (Collider obj in Enemys)
            {
                // 각 오브젝트와의 거리 계산
                float dis = Vector3.Distance(currentPos, obj.transform.position);

                // 가장 가까운 오브젝트를 업데이트
                if (dis < closestDis)
                {
                    closestDis = dis;
                    closestObj = obj;
                }
            }

            // 가장 가까운 오브젝트가 있다면 해당 방향으로 회전
            if (closestObj != null)
            {
                Vector3 dir = closestObj.transform.position - currentPos;
                dir.y = 0; // Y축은 고정하고 수평 회전만 적용

                Quaternion targetRotation = Quaternion.LookRotation(dir);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemys.Remove(other);
        }
    }
}
