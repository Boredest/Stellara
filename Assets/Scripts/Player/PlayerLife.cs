using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer playerSprite;
    [SerializeField] private float respawnTime = 2f;
    [SerializeField] private ParticleSystem deathPS;
    [SerializeField] AudioClip playerExplodeSound;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            PlayerDeath();
        }

        else if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        Debug.Log("Player Death.");
        rb.bodyType = RigidbodyType2D.Static;
        playerSprite.enabled = false;
        deathPS.Play();
        AudioManager.Instance.PlaySound(playerExplodeSound);
        Invoke("RestartLevel", respawnTime);

    }

    private void RestartLevel()
    {
        Debug.Log("Restarting level..");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
