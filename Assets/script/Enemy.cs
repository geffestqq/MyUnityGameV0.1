using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
    public bool FlipEnemy;
    public float seeDistance = 10f;
    private Transform target;
    public float minDistance;
    public float followDistance;
    public Vector3 offset;
    Vector3 targetPos;
    public float interpVelocity;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        targetPos = transform.position;
    }

    
    void FixedUpdate()
    {
        if (Vector3.Distance (transform.position, target.transform.position) < seeDistance) 
        {   
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;

            Vector3 targetDirection = (target.transform.position - posNoZ);

            interpVelocity = targetDirection.magnitude * 10f;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.05f);
        }

        if(Player.transform.position.x>transform.position.x && !FlipEnemy){
        FlipEnemy=false;
        Flip();
        }
        else if(Player.transform.position.x<transform.position.x && FlipEnemy){
        
        FlipEnemy=true;
        Flip();
        }
    }

    void Flip()
    {
        FlipEnemy = !FlipEnemy;
        transform.Rotate(0f, 180f, 0f);
    }
}
