using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum eDefenseType { ARMOR, SHIELD, HEALTH };

[CreateAssetMenu(fileName = "Enemy Data", menuName = "Scriptable Object / EnemyData")]
public class EnemyData : ScriptableObject
{
    public eDefenseType[] defenseOrder;

    public float speed;
    public float armor;
    public float shield;
    public float health;
}
