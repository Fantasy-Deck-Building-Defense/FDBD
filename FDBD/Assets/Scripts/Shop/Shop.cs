using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject shop;
    
    private List<Unit> staticUnitCards = new List<Unit>();
    private List<Unit> randomUnitCards = new List<Unit>();

    private GameObject staticCardObj;
    private GameObject randomCardObj;

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

    public void SetShopCards(List<Unit> staticCards, List<Unit> randomCards)
    {
        staticUnitCards = staticCards;
        randomUnitCards = randomCards;
    }

    public void SetShopCard(bool isRandomCard, Unit card)
    {
        if(isRandomCard) randomUnitCards.Add(card);
        else staticUnitCards.Add(card);
    }
}
