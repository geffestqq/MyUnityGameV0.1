using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    
    public GameObject playercoin;
    public int Coins;
    public int Price;
    public GameObject weapon1;
    public GameObject weapon2;
    public Text PriceText;

    void Start()
    {
        weapon1.SetActive(true);
        weapon2.SetActive(false);
    }
    void Update()
    {   
        Coins = playercoin.GetComponent<Money>().Coin;
        PriceText.text = Price.ToString ("0");
    }
    public void Buy()
    {
        if(Coins >= Price)
        {
            NewWeapon();
        }
    }
    public void NewWeapon()
    {
        weapon1.SetActive(false);
        weapon2.SetActive(true);
    }
}
