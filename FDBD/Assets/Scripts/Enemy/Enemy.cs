using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Enemy info")]
    private float hp;
    private float speed;
    private float armor;
    private float shield;
    bool isDie;

    private NavMeshAgent navMeshAgent;
    public Transform destination;

    public void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.destination = destination.position;
    }
}
