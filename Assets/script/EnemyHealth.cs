using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int Health = 3;
    public GameObject HPBar1;
    public GameObject HPBar2;
    public GameObject HPBar3;
    public GameObject Weapon;
    void Update()
    {
       if(Health <=0)
        {
            Health = 0;
            HPBar1.SetActive(false);
            HPBar2.SetActive(false);
            HPBar3.SetActive(false);
            Destroy(gameObject);
        }
        if (Health >= 1)
        {         
            HPBar1.SetActive(true);
            HPBar2.SetActive(false);
            HPBar3.SetActive(false);        
        }
        if (Health >= 2)
        {
            HPBar1.SetActive(false);
            HPBar2.SetActive(true);
            HPBar3.SetActive(false);
        }
        if (Health >= 3)
        {
            HPBar1.SetActive(false);
            HPBar2.SetActive(false);
            HPBar3.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag =="Bullet")
        {
            Health--;
        }
    }
}
