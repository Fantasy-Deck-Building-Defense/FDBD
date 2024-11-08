using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject shop;
    private List<Unit> unitCards = new List<Unit>();

    // Start is called before the first frame update
    void Start()
    {
        shop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            shop.SetActive(!shop.activeSelf);
        }
    }

    public void SetShopCards(List<Unit> cards)
    {
        unitCards = cards;
    }

    public void SetShopCard(Unit card)
    {
        unitCards.Add(card);
    }
}
