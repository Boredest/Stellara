using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private CircleCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;


    private float dirX = 0f;
    private float dirY = 0f;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private ParticleSystem dust;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
         dirX = Input.GetAxisRaw("Horizontal");
         dirY = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown("space") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            
        }

        UpdateAnimations();
    }

    private void UpdateAnimations()
    {
        if (dirX > 0)
        {
            CreateDust();
            anim.SetBool("Running", true);
            sprite.flipX = true;
            
        }
        else if (dirX < 0)
        {
            CreateDust();
            anim.SetBool("Running", true);
            sprite.flipX = false;
            
        }

        else
        {
            anim.SetBool("Running", false);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.CircleCast(coll.bounds.center, coll.radius, Vector2.down, .1f, jumpableGround);
      
    }

    private void CreateDust()
    {
        dust.Play();
    }
}
