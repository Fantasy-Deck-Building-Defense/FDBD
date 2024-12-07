using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor; // AssetDatabase 사용을 위한 추가 namespace
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

        if (roundTimer <= 0 || enemyController.all_count == 0) // 게임 종료 조건 두 가지
            EndRound();
    }

    private void InitProgram()
    {
        // unit setting
        string[] guids = AssetDatabase.FindAssets("t:UnitData"); // UnitData라는 타입을 가지고 있는 asset을 모두 가져온다 
        units = new UnitData[guids.Length];

        for (int i = 0; i < guids.Length; i++)
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);
            units[i] = AssetDatabase.LoadAssetAtPath<UnitData>(path);
        }

        shop = GameObject.Find("Canvas_ScreenSpace").GetComponent<Shop>();
    }

    private void InitGame()
    {
        // 처음 게임을 시작할 때
        level = 0;
        isGameStart = true;
        roundTimer = 60f;

        // 상점 카드 세팅
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
        enemyController.InitRound();
    }

    private void UpdateRound()
    {
        roundTimer -= Time.deltaTime;
    }
    private void EndRound()
    {
        isRoundStart = false;
        CheckRoundResult();

        enemyController.EndRound();
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
        isRoundStart = false;
        isGameStart = false;
        enemyController.EndGame();
        unitController.EndGame();
    }

    private void SetNextRound()
    {
        enemyController.SetNextRound();

        // set next round
        roundTimer = 60;
        ++level;
    }

    public void RestartGame()
    {
        isGameStart = true;

        enemyController.RestartGame();
        InitGame();
    }
}
