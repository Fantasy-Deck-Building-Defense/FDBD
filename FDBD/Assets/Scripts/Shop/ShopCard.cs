using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ShopCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Text cardInfo;
    private UnitData unitCard;

    private void Awake()
    {
        cardInfo = GameObject.Find("CardInfo").GetComponent<Text>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // 마우스가 텍스트 위로 올라갔을 때 텍스트 변경
        if (cardInfo != null)
        {
            //cardInfo.text = gameObject.name;

            string price = "가격 : " + unitCard.cardData.price;
            string mana = "사용시 드는 마나: " + unitCard.cardData.mana;
            string count = "개수 : " + unitCard.cardData.count;
            string explain = "설명 : " + unitCard.cardData.explain;

            cardInfo.text = price + "\n" + mana + "\n" + count + "\n" + explain;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // 마우스가 텍스트에서 벗어났을 때 원래 텍스트로 복원
        if (cardInfo != null)
        {
            cardInfo.text = "Exit";
        }
    }

    public void SelectCard()
    {
        // 덱 쪽으로 넘겨주기
    }

    public void SetCard(UnitData card)
    {
        unitCard = card;
    }
}
