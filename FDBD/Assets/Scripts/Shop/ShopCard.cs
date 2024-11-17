using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ShopCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Unit unitCard;
    public Text targetText;

    public void Start()
    {
        unitCard = new Unit();
        unitCard.unitName = "name";

    }

    public void OnButtonClick()
    {
        //Debug.Log(cardObject.name);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // ���콺�� �ؽ�Ʈ ���� �ö��� �� �ؽ�Ʈ ����
        targetText.text = "Enter";/*unitCard.unitName;*/
        Debug.Log("Is Work");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // ���콺�� �ؽ�Ʈ���� ����� �� ���� �ؽ�Ʈ�� ����
        targetText.text = "Exit";
    }
}
