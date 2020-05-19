using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //скорость пули
    public float speed = 20f;
    public Rigidbody2D rb;
    public int Damage = 1;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

 
    void Update()
    {
        //уничтожение снаряда
        StartCoroutine(SpawnCD());
    }
    //столкновение
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            Destroy(gameObject);
        }
    }
    // уничтожение объекта через 5 сек
    IEnumerator SpawnCD()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject, 0.5f);
    }
}
