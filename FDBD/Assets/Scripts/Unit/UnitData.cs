using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit Data", menuName = "Scriptable Object / UnitData")]
public class UnitData : ScriptableObject
{
    // 유닛 기본 정보
    public int unitNumber;     // 유닛 번호
    public string unitName;    // 유닛명
    public string unitRace;    // 유닛 종족
    public string unitJob;     // 유닛 직업


    public AttackData attackData;
    public CardData cardData;

    [System.Serializable]
    public struct AttackData
    {
        // 유닛 타입
        public bool isAttack;      // 공격형?
        public bool isResource;    // 자원형?
        public bool isEffect;      // 효과형?

        // 유닛 공격 타입
        public eAttackType attackType;
        public float strength;     // 공격력
        public float speed;        // 공격 속도
        public float range;        // 사거리
    }

    [System.Serializable]
    public struct CardData
    {
        // shop
        public int price;      // 가격
        public int count;      // 개수
        public string explain; // 설명

        // use card
        public int mana;       // 카드 사용시 드는 마나
        public List<CardEffect> effect; // 카드 효과
    }

    [System.Serializable]
    public struct CardEffect
    {
        public eEffectKeyWord key;
        public int value;
    }
}
