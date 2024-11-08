using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy spawn info")]
    [SerializeField] private Transform EnemySpawnPos;
    [SerializeField] private float spawnSpeed;
    [SerializeField] private int spawnCount;

    [Header("Enemy info for level")]
    [SerializeField] private List<EnemyData> enemyDatas;

    [Header("Selected Enemy info")]
    [SerializeField] private DefensePower enemyPower_UI;
    public Enemy selectedEnemy { get; private set; }
    public int currentCount { get; set; }
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
