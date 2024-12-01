using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject shop;

    public GameObject[] staticUnitCards = new GameObject[6];
    public GameObject[] randomUnitCards = new GameObject[6];

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        shop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) shop.SetActive(!shop.activeSelf);
    }

    public void SetShopCards(UnitData[] staticCards, UnitData[] randomCards)
    {
        for(int i = 0; i < 6; i++)
        {
            staticUnitCards[i].GetComponent<ShopCard>().SetCard(staticCards[i]);
            randomUnitCards[i].GetComponent<ShopCard>().SetCard(randomCards[i]);
        }
    }
}
