using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // 유닛 기본 정보
    public string unitName;        // 유닛명
    public int money;              // 유닛가격
    public int mana;               // 유닛 사용시 드는 마나
    public int count;              // -1 is infinity
    public string explain;         //(설명)


    // 유닛 타입
    //bool 공격유닛인가?;
    //bool 자원유닛인가?;
    //bool 효과유닛인가?;

    // 유닛 공격 타입
    eAttackType attackType = eAttackType.NORMAL;
    float strength = 50.0f;
    float range;            // 유닛 사거리
    float attackSpeed = 0.5f;      // 유닛 공격 속도
    float attackCoolDown = 0.0f;   // 타이머

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
