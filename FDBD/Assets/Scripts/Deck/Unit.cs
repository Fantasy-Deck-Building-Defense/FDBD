using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // ���� �⺻ ����
    string unitName;        // ���ָ�
    float range;            // ���� ��Ÿ�
    int money;              // ���ְ���
    int mana;               // ���� ���� ��� ����
    int count;              // -1 is infinity
    string explain;         //(����)

    // ���� Ÿ��
    //bool ���������ΰ�?;
    //bool �ڿ������ΰ�?;
    //bool ȿ�������ΰ�?;

    // ���� ���� Ÿ��
    eAttackType attackType;

    private List<Collider> Enemys = new List<Collider>();

    // ���� �Լ�
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

            // ���� ������Ʈ�� ��ġ
            Vector3 currentPos = transform.position;

            foreach (Collider obj in Enemys)
            {
                // �� ������Ʈ���� �Ÿ� ���
                float dis = Vector3.Distance(currentPos, obj.transform.position);

                // ���� ����� ������Ʈ�� ������Ʈ
                if (dis < closestDis)
                {
                    closestDis = dis;
                    closestObj = obj;
                }
            }

            // ���� ����� ������Ʈ�� �ִٸ� �ش� �������� ȸ��
            if (closestObj != null)
            {
                Vector3 dir = closestObj.transform.position - currentPos;
                dir.y = 0; // Y���� �����ϰ� ���� ȸ���� ����

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
