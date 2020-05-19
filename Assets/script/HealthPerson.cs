using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPerson : MonoBehaviour
{
    public int Health = 2;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    void Update()
    {
       if(Health <=0)
        {
            Health = 0;
            Heart1.SetActive(false);
            Heart2.SetActive(false);
            Heart3.SetActive(false);
            DieScene();
        }
        if (Health >= 1)
        {         
            Heart1.SetActive(true);
            Heart2.SetActive(false);
            Heart3.SetActive(false);          
        }
        if (Health >= 2)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(false);
        }
        if (Health >= 3)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Enemy")
        {
            Health--;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Life")
        {
            Health++;
            Destroy(collision.gameObject);
        }
    }
    void DieScene()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
