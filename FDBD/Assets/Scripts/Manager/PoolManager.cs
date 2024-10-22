using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [Header("prefab list")]
    [Tooltip("Ǯ���Ϸ��� ������Ʈ�� ���� ����Ʈ. ���ӸŴ������� PoolManager.Get(������Ʈ �̸�) �ϸ� ������ �� �ִ�.")]
    [SerializeField] private GameObject[] prefabs;

    private Dictionary<string, GameObject> prefabDictionary;
    private Dictionary<string, List<GameObject>> pools;
    private void Awake()
    {
        prefabDictionary = new Dictionary<string, GameObject>();

        for (int i = 0; i < prefabs.Length; ++i)
        {
            prefabDictionary[prefabs[i].name] = prefabs[i];
        }

        pools = new Dictionary<string, List<GameObject>>();

        for (int i = 0; i < prefabs.Length; ++i)
        {
            pools[prefabs[i].name] = new List<GameObject>();
        }
    }

    // request object
    public GameObject Get(string prefabName)
    {
        if (!pools.ContainsKey(prefabName))
        {
#if UNITY_EDITOR
            Debug.LogError("Dictionary does not contain " + prefabName);
#endif
            return null;
        }

        GameObject requested = null;

        var pool = pools[prefabName];

        // get object in pool
        foreach (GameObject obj in pool)
        {
            if (!obj.activeSelf)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        // add object in pool
        requested = Instantiate(prefabDictionary[prefabName], this.transform);
        pool.Add(requested);
        return requested;
    }
}
