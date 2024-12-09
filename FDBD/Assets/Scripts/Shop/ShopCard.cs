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
        // ���콺�� �ؽ�Ʈ ���� �ö��� �� �ؽ�Ʈ ����
        if (cardInfo != null)
        {
            //cardInfo.text = gameObject.name;

            string price = "���� : " + unitCard.cardData.price;
            string mana = "���� ��� ����: " + unitCard.cardData.mana;
            string count = "���� : " + unitCard.cardData.count;
            string explain = "���� : " + unitCard.cardData.explain;

            cardInfo.text = price + "\n" + mana + "\n" + count + "\n" + explain;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // ���콺�� �ؽ�Ʈ���� ����� �� ���� �ؽ�Ʈ�� ����
        if (cardInfo != null)
        {
            cardInfo.text = "Exit";
        }
    }

    public void SelectCard()
    {
        // �� ������ �Ѱ��ֱ�
    }

    public void SetCard(UnitData card)
    {
        unitCard = card;
    }
}
