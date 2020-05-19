using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public int Coin;
	public Text CoinText;

    void Start()
    {
       
    }

    
    void Update()
    {
        CoinText.text = Coin.ToString ("0");
        if(Coin <= 0)
        {
			Coin = 0;
		}
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag=="Coin")
        {
            Coin++;
            Destroy (col.gameObject);
        }
    }
}
