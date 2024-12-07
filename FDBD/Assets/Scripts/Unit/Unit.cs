using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private UnitData unitData;

    private List<Collider> Enemys = new List<Collider>();
    private float attackCoolDown = 0.0f;

    private UnityEngine.AI.NavMeshAgent agent;
    [SerializeField] private bool isMove => agent.velocity.sqrMagnitude > 0;

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
        if (attackCoolDown > 0 || isMove) return false;

        enemy.GetComponent<Enemy>().Attack(unitData.attackData.attackType, unitData.attackData.strength);
        attackCoolDown = unitData.attackData.speed;
        if (!enemy.gameObject.activeSelf) return true;

        return false;
    }
}
