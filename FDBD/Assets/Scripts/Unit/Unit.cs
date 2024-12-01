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

    public void OnTriggerEnter(Collider other)
    {
        if (isMove) return;

        if (other.CompareTag("Enemy"))
        {
            Enemys.Add(other);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (isMove) return;

        if (other.CompareTag("Enemy"))
        {
            Enemys.Remove(other);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (isMove) return;

        if (other.CompareTag("Enemy"))
        {
            Collider closestObject = null;
            float closestDistance = Mathf.Infinity;

            Vector3 currentPosition = transform.position;

            foreach (Collider obj in Enemys)
            {
                float distance = Vector3.Distance(currentPosition, obj.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestObject = obj;
                }
            }

            if (closestObject != null)
            {
                Vector3 direction = closestObject.transform.position - currentPosition;
                direction.y = 0;

                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);

                if (attackCoolDown <= 0)
                {
                    other.GetComponent<Enemy>().Attack(unitData.attackData.attackType, unitData.attackData.strength);
                    attackCoolDown = unitData.attackData.speed;
                }

                if (!other.gameObject.activeSelf) Enemys.Remove(other);
            }
        }
    }
}
