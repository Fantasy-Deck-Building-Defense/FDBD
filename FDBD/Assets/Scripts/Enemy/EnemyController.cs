using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy spawn info")]
    [SerializeField] private Transform EnemySpawnPos;
    [SerializeField] private float spawnSpeed;
    [SerializeField] private int spawnCount;
    [SerializeField] private int currentCount;

    public void UpgradeSpawnPattern()
    {

    }
    public void StartSpawnEnemies()
    {
        StartCoroutine(SpawnEnemies());
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

}
