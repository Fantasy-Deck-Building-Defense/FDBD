using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Enemy info")]
    private float hp = 100;
    private float speed;
    private float armor;
    private float shield;
    bool isDie => hp <= 0;

    private NavMeshAgent agent;
    [SerializeField] private Transform[] destinations;
    [SerializeField] private int destinationIndex;

    public void Start()
    {
        GameObject[] destinationObjects = GameObject.FindGameObjectsWithTag("Destination");
        destinations = new Transform[destinationObjects.Length];

        for (int i = 0; i < destinationObjects.Length; i++)
        {
            destinations[i] = destinationObjects[i].transform;
        }

        destinationIndex = 0;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destinations[destinationIndex].position);
    }

    public void ResetState()
    {
        hp = 100;
        shield = 100;
        armor = 100;

        destinationIndex = 0;
        //agent.ResetPath();
        agent.SetDestination(destinations[destinationIndex].position);
    }

    private void OnEnable()
    {
        if (agent != null)
        {
            ResetState();
        }
    }

    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            MoveToNextPoint();
    }

    private void MoveToNextPoint()
    {
        if (destinationIndex >= destinations.Length - 1)
            destinationIndex = 0;
        else
            ++destinationIndex;

        agent.SetDestination(destinations[destinationIndex].position);
    }

    public void Attack(eAttackType type, float strength)
    {
        Attacked();

        switch (type)
        {
            case eAttackType.NORMAL:
                {
                    hp -= strength;
                }
                break;
            case eAttackType.PHYSICS:
                {

                }
                break;
            case eAttackType.MAGIC:
                {

                }
                break;
            default:
                break;
        }

        if (isDie)
            Die();
    }

    private void Attacked()
    {
        // attacked effect
    }

    private void Die()
    {
        GameManager.Instance.unitController.thisRound_killCount++;
        this.gameObject.SetActive(false);
    }
}
