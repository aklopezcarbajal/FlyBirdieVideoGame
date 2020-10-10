using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private GameManager gameManager;
    private Vector3 startPosition = new Vector3(-2.5f, 0.0f, 0.0f);
    public float force;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
            //increase score
            gameManager.IncreaseScore();
            //play sound
        }
        if (col.gameObject.CompareTag("Obstacle")) 
        {
            //Game over
            gameManager.GameOver();
            //play sound
        }

    }
}
