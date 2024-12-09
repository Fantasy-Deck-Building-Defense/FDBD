using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCardBoard : MonoBehaviour
{
    private int gold;
    private int mana;
    private int manaStone;
    private List<UnitData> handCards;

    // Start is called before the first frame update
    void Start()
    {
        manaStone = 0;
        Reset();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Reset()
    {
        gold = 0;
        mana = 0;
    }

    public void SetHandCards(List<UnitData> cards)
    {
        handCards = cards;
    }

    void UseCard(UnitData card)
    {
        if (mana < card.cardData.mana) return;

        foreach (var data in card.cardData.effect)
        {
            mana -= card.cardData.mana;

            switch (data.key)
            {
                case eEffectKeyWord.GOLD: gold += data.value; break;
                case eEffectKeyWord.MANA: mana += data.value; break;
                case eEffectKeyWord.MANASTONE: manaStone += data.value; break;
                case eEffectKeyWord.IFMANA: if(mana <= 0) mana += data.value; break;
                case eEffectKeyWord.DRAW:
                    {

                    }
                    break;
                case eEffectKeyWord.GET_SHOPCARD:
                    {
                        
                    }
                    break;
                case eEffectKeyWord.EFFECT_DOUBLE:
                    {
                        
                    }
                    break;
            }
        }
    }
}
