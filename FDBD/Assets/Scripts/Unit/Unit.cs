using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // ���� �⺻ ����
    string unitName;        // ���ָ�
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
    float strength;
    float range;            // ���� ��Ÿ�
    float attackSpeed;      // ���� ���� �ӵ�

    private void Start()
    {
        
    }

    void Update()
    {
        //RaycastHit hit;
    }
}
