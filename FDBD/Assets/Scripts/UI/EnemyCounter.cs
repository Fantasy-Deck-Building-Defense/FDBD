using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countText;
    private void Awake()
    {
        countText = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        if (GameManager.Instance.isRoundStart)
        {
            countText.text = string.Format("{0}", GameManager.Instance.enemyController.all_count);
        }
    }
}
