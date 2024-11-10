using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // ���� �⺻ ����
    public string unitName;        // ���ָ�
    public int money;              // ���ְ���
    public int mana;               // ���� ���� ��� ����
    public int count;              // -1 is infinity
    public string explain;         //(����)


    // ���� Ÿ��
    //bool ���������ΰ�?;
    //bool �ڿ������ΰ�?;
    //bool ȿ�������ΰ�?;

    // ���� ���� Ÿ��
    eAttackType attackType = eAttackType.NORMAL;
    float strength = 50.0f;
    float range;            // ���� ��Ÿ�
    float attackSpeed = 0.5f;      // ���� ���� �ӵ�
    float attackCoolDown = 0.0f;   // Ÿ�̸�

    private void Start()
    {

    }

    void Update()
    {
        // Attack Cool Time
        if (attackCoolDown > 0) attackCoolDown -= Time.deltaTime;

        //RaycastHit hit;
    }

    public bool EnemyAttack(Collider enemy)
    {
        if (attackCoolDown > 0) return false;

        enemy.GetComponent<Enemy>().Attack(attackType, strength);
        attackCoolDown = attackSpeed;
        if (!enemy.gameObject.activeSelf) return true;

        return false;
    }
}
