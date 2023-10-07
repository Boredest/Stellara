using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    [SerializeField] private float fallSpeed;
    [SerializeField] private ParticleSystem deathPS;
    
    [SerializeField] AudioClip brickExplodeSound;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if(collision.gameObject.tag == "Environment" || collision.gameObject.tag == "Spike")
        {
            deathPS.transform.parent = null;
            deathPS.Play();
            AudioManager.Instance.PlaySound(brickExplodeSound);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(0, -fallSpeed));
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("isTrigger");
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

        }
    }
}
