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

    private AudioSource source;
    public Animator playerAnimator;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRb       = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        gameManager    = GameObject.Find("GameManager").GetComponent<GameManager>();
        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))//gameManager.gameOn)//GetButtonDown("Fire1")
        {
            if(gameManager.gameOn)
                playerRb.AddForce(Vector2.up * force);///ForceMode2D.Force
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Score") && gameManager.gameOn)
        {
            gameManager.IncreaseScore();
            source.PlayOneShot(scoreSound, 0.5f);
            playerAnimator.SetTrigger("hit_trigger");
        }
        if (col.gameObject.CompareTag("Obstacle") && gameManager.gameOn) 
        {
            //Game over
            gameManager.GameOver();
            source.PlayOneShot(crashSound, 0.5f);
            playerAnimator.SetTrigger("hit_trigger");
        }

    }
}
