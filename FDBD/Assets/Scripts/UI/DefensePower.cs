using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// enemy defense power ui
// armor - blue
// shield - yellow
// hp - red

public class DefensePower : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    [SerializeField] private Slider Armor;
    [SerializeField] private Slider Shield;
    [SerializeField] private Slider Hp;

    [SerializeField] private Enemy enemy;

    private void Start()
    {
        Armor.value = 0;
        Shield.value = 0;
        Hp.value = 0;

        UI.SetActive(false);
    }

    public void SetEnemyNow(Enemy info)
    {
        if(enemy == null)
            UI.SetActive(false);
        else
            UI.SetActive(true);

        enemy = info;
    }

    private void Update()
    {
        if (enemy == null)
            return;

        foreach (var power in enemy.defenseOrder)
        {
            switch(power.type)
            {
                case eDefenseType.ARMOR:
                    Armor.value = power.amount * 0.01f;
                    break;
                case eDefenseType.SHIELD:
                    Shield.value = power.amount * 0.01f;
                    break;
                case eDefenseType.HEALTH:
                    Hp.value = power.amount * 0.01f;
                    break;
            }
        }

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(enemy.transform.position);
        UI.transform.position = screenPosition + new Vector3(0, 3f, 0);
    }
}
