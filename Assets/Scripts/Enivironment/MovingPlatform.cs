using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform posA, posB;
    public Transform startPos;
    public float speed;

    private Rigidbody2D platformRB;
    private Vector3 targetPos;

    

    private void Start()
    {
        platformRB = GetComponent<Rigidbody2D>();
        targetPos = startPos.position;
    }

    /*private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, posA.position) < 0.05f)
        {
            targetPos = posB.position;
        }

        if (Vector2.Distance(transform.position, posB.position) < 0.05f)
        {
            targetPos = posA.position;
        }

        
        platformRB.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime);
    }*/

    private void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < 0.05f)
        {
            targetPos = posB.position;
        }

        if (Vector2.Distance(transform.position, posB.position) < 0.05f)
        {
            targetPos = posA.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            Rigidbody2D playerRB = collision.GetComponent<Rigidbody2D>();

            if (playerRB != null)
            {
                
                playerRB.velocity = new Vector2(playerRB.velocity.x+platformRB.velocity.x, playerRB.velocity.y);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D playerRB = collision.GetComponent<Rigidbody2D>();
            if (playerRB != null)
            {

                playerRB.velocity = playerRB.velocity;
            }

        }
    }
}


