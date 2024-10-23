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
    private void Update()
    {
        if(!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance + 0.1)
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
}
