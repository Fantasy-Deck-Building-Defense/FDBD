using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using UnityEngine.UI;
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
    public bool isGameStart;
    public bool isRoundStart;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI gameProcess;
    [SerializeField] private Image FadeImg;
    [SerializeField] private Button button;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
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

    private void InitGame()
    {
        SetEndGameUI(false);

        // 처음 게임을 시작할 때
        level = 0;
        isGameStart = true;
        roundTimer = 60f;

        // ui
        gameProcess.text = "Game Start";
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
        SetEndGameUI(true);
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
    private void SetEndGameUI(bool isActive)
    {
        FadeImg.gameObject.SetActive(isActive);
        button.gameObject.SetActive(isActive);
    }
}
