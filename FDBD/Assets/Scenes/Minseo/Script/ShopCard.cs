using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCard : MonoBehaviour
{
    public GameObject cardObject;


    public void OnButtonClick()
    {
        Debug.Log(cardObject.name);
    }
}
