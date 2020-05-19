using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMove : MonoBehaviour
{
    public Joystick joystick;
    float speed = 10f;
    bool slashattack = true;
    bool shootattack = true;
    public GameObject Slattack;
    public float move;
    Rigidbody2D rb;
    Animator anim;
    public bool isLookingLeft;
    public bool ground = false;
    public GameObject bullet;
    public GameObject ShopButton;
    public Transform SpawnPos;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Slattack.SetActive(false);
    }


    void FixedUpdate()
    {
        move = joystick.Horizontal();
        anim.SetInteger("Anim", Convert.ToInt32(move));
        Vector3 theScale = transform.localScale;
        if (joystick.Vertical() > 0)
        Jump();

        if (move < 0 && !isLookingLeft)
        TurnTheReap();
        if (move > 0 && isLookingLeft)
        TurnTheReap();


        transform.Translate(transform.right * move * speed * Time.fixedDeltaTime);   
    }

    public void Jump()
    {
        if (ground == true)
            rb.AddForce(transform.up * 10, ForceMode2D.Impulse);
        anim.SetTrigger("Jump");
    }

    public void Slattatck()
    {
        if(slashattack == true)
        {
            slashattack = false;
           Slattack.SetActive(true);
            anim.SetTrigger("SlashAttack");
            Invoke("ResetAtt", 0.5f);
        }
    }
    private void ResetAtt()
    {
        Slattack.SetActive(false);
        slashattack = true;
    }
    public void ShootAttack()
    {
        if(shootattack ==true)
        {
            shootattack = false;
            anim.SetTrigger("Shoot");
            Instantiate(bullet, SpawnPos.position, SpawnPos.rotation);
            Invoke("ResetShootatt", 0.5f);
        }
    }
    private void ResetShootatt()
    {
        shootattack = true;
    }
    void TurnTheReap()
    {
        isLookingLeft = !isLookingLeft;
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Shop")
        {
            ShopButton.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Shop")
        {
            ShopButton.SetActive(false);
        }
    }
}

