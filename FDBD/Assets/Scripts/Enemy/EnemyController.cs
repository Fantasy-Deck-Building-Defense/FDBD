using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy spawn info")]
    [SerializeField] public Transform EnemySpawnPos;
    [SerializeField] private float spawnSpeed;
    [SerializeField] private int spawnCount;
    [SerializeField] private int thisRound_count;
    private List<GameObject> enemyList = new List<GameObject>();

    [Header("Enemy info for level")]
    [SerializeField] private List<EnemyData> enemyDatas;

    [Header("Selected Enemy info")]
    [SerializeField] private DefensePower enemyPower_UI;
    public Enemy selectedEnemy { get; private set; }

    public event System.Action<int> OnEnemyCountChanged;
    private int _AllCount;
    public int all_count 
    { 
        get => _AllCount;
        set
        {
            if (_AllCount != value)
            {
                _AllCount = value;
                OnEnemyCountChanged?.Invoke(_AllCount);
            }
        }
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.transform.CompareTag("Enemy"))
            {
                selectedEnemy = hit.collider.gameObject.GetComponent<Enemy>();
                enemyPower_UI.SetEnemyNow(selectedEnemy);
            }
        }
    }

    public void RemoveEnemy(GameObject enemy)
    {
        enemy.gameObject.transform.position = EnemySpawnPos.position;
        enemy.gameObject.SetActive(false);
        enemyList.Remove(enemy);
    }

    public void SetEnemyStop(bool isStop)
    {
        foreach (GameObject enemy in enemyList)
        {
            enemy.GetComponent<Enemy>().IsAgentStop(isStop);
        }
    }

    public void InitRound()
    {
        all_count += 50;
        StartCoroutine(SpawnEnemies());
        SetEnemyStop(false);
    }

    public void EndRound()
    {
        SetEnemyStop(true);
    }

    public void DestroyAllEnemies()
    {
        foreach(GameObject enemy in enemyList)
        {
            enemy.transform.position = EnemySpawnPos.position;
            enemy.gameObject.SetActive(false);
        }

        enemyList.Clear();
    }

    private IEnumerator SpawnEnemies()
    {
        while (spawnCount > thisRound_count)
        {
            yield return new WaitForSeconds(spawnSpeed);
            var enemy = GameManager.Instance.poolManager.Get("Enemy");
            enemy.transform.position = EnemySpawnPos.position;
            enemyList.Add(enemy);
            ++thisRound_count;
        }

        yield break;
    }

    public EnemyData GetCurrentEnemyData()
    {
        return enemyDatas[GameManager.Instance.level];
    }

    public void SetNextRound()
    {
        thisRound_count = 0;
        spawnSpeed = enemyDatas[GameManager.Instance.level].spawnSpeed;
    }
    public void EndGame()
    {
        thisRound_count = 0;
        _AllCount = 0;
    }

    public void RestartGame()
    {
        DestroyAllEnemies();
    }
}
