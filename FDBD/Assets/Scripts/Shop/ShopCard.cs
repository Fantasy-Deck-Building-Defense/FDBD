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
        // 마우스가 텍스트 위로 올라갔을 때 텍스트 변경
        targetText.text = "Enter";/*unitCard.unitName;*/
        Debug.Log("Is Work");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // 마우스가 텍스트에서 벗어났을 때 원래 텍스트로 복원
        targetText.text = "Exit";
    }
}
