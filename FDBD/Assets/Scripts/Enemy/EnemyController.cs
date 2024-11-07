using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy spawn info")]
    [SerializeField] private Transform EnemySpawnPos;
    [SerializeField] private float spawnSpeed;
    [SerializeField] private int spawnCount;

    [Header("Enemy info for level")]
    [SerializeField] private List<EnemyData> enemyDatas;

    public int currentCount { get; set; }

    public void UpgradeSpawnPattern()
    {

    }

    public void StartSpawnEnemies()
    {
        StartCoroutine(SpawnEnemies());
    }

    public void DestroyAllEnemies()
    {

    }

    private IEnumerator SpawnEnemies()
    {
        while (spawnCount > currentCount)
        {
            yield return new WaitForSeconds(spawnSpeed);
            var enemy = GameManager.Instance.poolManager.Get("Enemy");
            enemy.transform.position = EnemySpawnPos.position;
            ++currentCount;
        }

        yield break;
    }

    public EnemyData GetCurrentEnemyData()
    {
        return enemyDatas[GameManager.Instance.level];
    }

}
