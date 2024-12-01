using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit Data", menuName = "Scriptable Object / UnitData")]
public class UnitData : ScriptableObject
{
    // ���� �⺻ ����
    public int unitNumber;     // ���� ��ȣ
    public string unitName;    // ���ָ�
    public string unitRace;    // ���� ����
    public string unitJob;     // ���� ����


    public AttackData attackData;
    public CardData cardData;

    [System.Serializable]
    public struct AttackData
    {
        // ���� Ÿ��
        public bool isAttack;      // ������?
        public bool isResource;    // �ڿ���?
        public bool isEffect;      // ȿ����?

        // ���� ���� Ÿ��
        public eAttackType attackType;
        public float strength;     // ���ݷ�
        public float speed;        // ���� �ӵ�
        public float range;        // ��Ÿ�
    }

    [System.Serializable]
    public struct CardData
    {
        // shop
        public int price;      // ����
        public int count;      // ����
        public string explain; // ����

        // use card
        public int mana;       // ī�� ���� ��� ����
        public List<CardEffect> effect; // ī�� ȿ��
    }

    [System.Serializable]
    public struct CardEffect
    {
        public eEffectKeyWord key;
        public int value;
    }
}
