using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Enemy info")]
    [SerializeField] private float speed;
    public List<DefenseType> defenseOrder = new List<DefenseType>();
    private bool isDie => defenseOrder.Count == 0;

    [Header("Enemy Route")]
    private NavMeshAgent agent;
    [SerializeField] private Transform[] destinations;
    [SerializeField] private int destinationIndex;

    public void Start()
    {
        // set enemy info
        SetEnemyData();

        // destination
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

    private void SetEnemyData()
    {
        EnemyData current = GameManager.Instance.enemyController.GetCurrentEnemyData();
        speed = current.speed;

        for (int i = 0; i < current.defenseOrder.Length; ++i)
        {
            switch (current.defenseOrder[i])
            {
                case eDefenseType.ARMOR:
                    {
                        defenseOrder.Add(new Armor(current.armor));
                    }
                    break;
                case eDefenseType.SHIELD:
                    {
                        defenseOrder.Add(new Shield(current.shield));
                    }
                    break;
                case eDefenseType.HEALTH:
                    {
                        defenseOrder.Add(new Health(current.health));
                    }
                    break;
                default:
                    break;
            }
        }
    }

    public void ResetState()
    {
        SetEnemyData();

        destinationIndex = 0;
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

        while (strength > 0)
        {
            // 우선 방어력 가져오기
            var defense = defenseOrder[0];

            // 방어
            strength = defense.Attacked(type, strength);
            Debug.Log("attacked");

            // 해당 방어력이 다 떨어지면 리스트에서 제거
            if (defense.amount <= 0)
                defenseOrder.RemoveAt(0);
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
