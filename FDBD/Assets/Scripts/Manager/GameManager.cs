using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor; // AssetDatabase ����� ���� �߰� namespace
using System;

using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Managers")]
    public PoolManager poolManager;
    public UIManager UIManager;
    public EnemyController enemyController;
    public UnitController unitController;


    [Header("Round info")]
    public int level;
    [SerializeField] private float _roundTimer;
    [SerializeField] private bool _isGameStart;
    [SerializeField] private bool _isRoundStart;

    [Header("Unit")]
    [SerializeField] private UnitData[] units;

    [Header("Shop")]
    [SerializeField] private Shop shop;

    public float roundTimer
    {
        get => _roundTimer;
        set
        {
            if (_roundTimer != value)
            {
                _roundTimer = value;
                checkRoundTime?.Invoke(_roundTimer);
            }
        }
    }
    public bool isGameStart
    {
        get => _isGameStart;
        set
        {
            if (_isGameStart != value)
            {
                _isGameStart = value;
                checkGameStart?.Invoke(_isGameStart);
            }
        }
    }
    public bool isRoundStart
    {
        get => _isRoundStart;
        set
        {
            if (_isRoundStart != value)
            {
                _isRoundStart = value;
                checkRoundStart?.Invoke(_isRoundStart);
            }
        }
    }

    public event System.Action<bool> checkGameStart;
    public event System.Action<bool> checkRoundStart;
    public event System.Action<float> checkRoundTime;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI gameProcess;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        InitProgram();
    }

    private void Start()
    {
        InitGame();
    }
    private void Update()
    {
        if (!isGameStart)
            return;

        if (!isRoundStart && Input.GetKeyDown(KeyCode.B))
            InitRound();

        if (!isRoundStart)
            return;

        UpdateRound();

        if (roundTimer <= 0 || enemyController.all_count == 0) // ���� ���� ���� �� ����
            EndRound();
    }

    private void InitProgram()
    {
        // unit setting
        string[] guids = AssetDatabase.FindAssets("t:UnitData"); // UnitData��� Ÿ���� ������ �ִ� asset�� ��� �����´� 
        units = new UnitData[guids.Length];

        for (int i = 0; i < guids.Length; i++)
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);
            units[i] = AssetDatabase.LoadAssetAtPath<UnitData>(path);
        }

        shop = GameObject.Find("Shop").GetComponent<Shop>();
    }

    private void InitGame()
    {
        // ó�� ������ ������ ��
        level = 0;
        isGameStart = true;
        roundTimer = 60f;

        // ui
        gameProcess.text = "Game Start";

        // ���� ī�� ����
        UnitData[] staticCards = new UnitData[6];
        UnitData[] randomCards = new UnitData[6];

        for (int i = 0; i < 6; i++)
        {
            staticCards[i] = units[i];

            int ranNum = Random.Range(0, units.Length);
            randomCards[i] = units[ranNum];
        }

        shop.SetShopCards(staticCards, randomCards);
    }


    private void InitRound()
    {
        isRoundStart = true;
        enemyController.StartSpawnEnemies();

        // ui
        gameProcess.text = "Round " + level + " begin";
    }

    private void UpdateRound()
    {
        roundTimer -= Time.deltaTime;
    }
    private void EndRound()
    {
        isRoundStart = false;
        CheckRoundResult();
    }
    private void CheckRoundResult()
    {
        if (enemyController.all_count < 50)  // monster count under 50
        {
            if (level < 30)
                SetNextRound();   // solve this round
            else
                EndGame(true);    // solve all round
        }
        else
        {
            EndGame(false);  // monster count over 50
        }
    }

    private void EndGame(bool isWin)
    {
        if (isWin)
            gameProcess.text = "Game Win";
        else
            gameProcess.text = "Game lose";

        isRoundStart = false;
        isGameStart = false;
        enemyController.EndGame();
    }

    private void SetNextRound()
    {
        // clear ui
        gameProcess.text = "Round " + level + " clear";

        enemyController.SetNextRound();

        // set next round
        roundTimer = 60;
        ++level;
    }

    public void RestartGame()
    {
        InitGame();
    }
}
