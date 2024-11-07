using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Managers")]
    public PoolManager poolManager;
    public EnemyController enemyController;
    public UnitController unitController;


    [Header("Round info")]
    public int level;
    public float roundTimer;
    public bool isRoundStart;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }
    private void Start()
    {
        level = 0;
        roundTimer = 60f;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
            InitRound();

        if (isRoundStart)
            UpdateRound();

        if (roundTimer <= 0 || unitController.thisRound_killCount >= 50) // ���� ���� ���� �� ����
            EndRound();
    }
    private void InitRound()
    {
        isRoundStart = true;
        enemyController.StartSpawnEnemies();
    }

    private void UpdateRound()
    {
        roundTimer -= Time.deltaTime;
    } 
    private void EndRound()
    {
        // round fin
        isRoundStart = false;
        roundTimer = 60;

        // calculate count
        unitController.SetNextRound();
    }
}
