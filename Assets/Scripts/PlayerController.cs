using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private GameManager gameManager;
    private Vector3 startPosition = new Vector3(-2.5f, 0.0f, 0.0f);
    public float force;

    public AudioClip scoreSound;
    public AudioClip crashSound;
    public AudioClip hitGround;

    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRb       = GetComponent<Rigidbody2D>();
        gameManager    = GameObject.Find("GameManager").GetComponent<GameManager>();
        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))//gameManager.gameOn)//GetButtonDown("Fire1")
        {
            if(gameManager.gameOn && gameManager.gravityOn)
                playerRb.AddForce(Vector2.up * force);///ForceMode2D.Force
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Score") && gameManager.gameOn)
        {
            gameManager.IncreaseScore();
            source.PlayOneShot(scoreSound, 0.5f);
        }
        if (col.gameObject.CompareTag("Obstacle") && gameManager.gameOn) 
        {
            gameManager.GameOver();
            source.PlayOneShot(crashSound, 0.5f);
        }
        if (col.gameObject.CompareTag("Ground") && gameManager.gameOn)
        {
            gameManager.GameOver();
            source.PlayOneShot(hitGround, 0.5f);
        }

    }
}
