using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChek : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            GetComponentInParent<PlayerMove>().ground = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            GetComponentInParent<PlayerMove>().ground = false;
    }
}
