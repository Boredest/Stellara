using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{

    private Rigidbody2D enemyRB;
    private SpriteRenderer sprRenderer;
    private CircleCollider2D coll;
    private float randomDirectionX;
    private float spriteHeight;


    [SerializeField] private float currentDirection;
    [SerializeField] private float enemyMoveSpeed = 4f;
    [SerializeField] private LayerMask wall;
    [SerializeField] private Transform groundCheck;


    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        sprRenderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<CircleCollider2D>();
        randomDirectionX = Random.Range(-1f, 1f);
        currentDirection = randomDirectionX;
        SetSpriteAndDirection();
    }

    private void Update()
    {
        enemyRB.velocity = new Vector2(currentDirection * enemyMoveSpeed, 0);
        CheckCollision();

    }

    private void SetSpriteAndDirection()
    {
        currentDirection *= -1;
        if (currentDirection > 0)
        {
            sprRenderer.flipX = true;
            currentDirection = 1;
        }
        else
        {
            sprRenderer.flipX = false;
            currentDirection = -1;
        }
    }

    private void CheckCollision()

    {

        float lineCastOffset = 0.5f;
        float heightOffset = 0.25f;
        Vector2 lineOrigin = new Vector2(transform.position.x, transform.position.y - heightOffset);
        Vector2 lineEnd;

        if (currentDirection > 0)
        {
            lineEnd = new Vector2(transform.position.x + lineCastOffset, transform.position.y - heightOffset);
        }
        else
        {
            lineEnd = new Vector2(transform.position.x - lineCastOffset, transform.position.y - heightOffset);
        }

        RaycastHit2D hit = Physics2D.Linecast(lineOrigin, lineEnd, wall);
        Debug.DrawLine(lineOrigin, lineEnd);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Spike"))
            {
                
                SetSpriteAndDirection();
            }
            else
            {
                
                SetSpriteAndDirection();
            }

        }


    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Environment"))
        {
            SetSpriteAndDirection();
        }

    }




}
