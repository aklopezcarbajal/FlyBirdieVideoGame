using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private GameManager gameManager;
    private Vector3 startPosition;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//GetButtonDown("Fire1")
        {
            playerRb.AddForce(Vector2.up * force);///ForceMode2D.Force
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Score"))
        {
            //increase score
            gameManager.score++;
            //play sound
        }
        if (col.gameObject.CompareTag("Obstacle")) 
        {
            //game over
            gameManager.gameOn = false;
            //play sound
        }

    }
}
