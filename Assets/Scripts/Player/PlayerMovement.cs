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
    private bool doubleJump;
    private bool isOnPlatform;

    private enum PlayerState { idle, running, jumping, falling }

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float lowJumpMultiplier = 2f;
    [SerializeField] private float jumpForce = 14f;

    [SerializeField] private ParticleSystem dust;

    [SerializeField] private AudioClip jumpSound;

    // [SerializeField] AudioClip jumpSound;

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
        HandlePlayerMovement();
        Jump();

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        
        UpdateAnimations();
    }
    private void HandlePlayerMovement()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }
    private void Jump()
    {

        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                doubleJump = !doubleJump;
                AudioManager.Instance.PlayJumpSound(jumpSound);
            }
            
        }
       
    }

    private void UpdateAnimations()
    {
        PlayerState state;
        if (dirX > 0)
        {
            CreateDust();
            state = PlayerState.running;
            sprite.flipX = true;

        }
        else if (dirX < 0)
        {
            CreateDust();
            state = PlayerState.running;
            sprite.flipX = false;

        }

        else
        {
            state = PlayerState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            
            state = PlayerState.jumping;
        }


        anim.SetInteger("State", (int)state);
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
