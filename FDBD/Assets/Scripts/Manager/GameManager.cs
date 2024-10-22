using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Managers")]
    public PoolManager poolManager;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

}
