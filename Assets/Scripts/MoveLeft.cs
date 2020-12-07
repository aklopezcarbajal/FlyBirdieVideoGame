using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    private GameManager gameManager;
    public float speed;
    private float leftBound = -10;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    void Update()
    {
        if(gameObject.CompareTag("Obstacle"))
        {
            if (gameManager.gameOn)
                transform.Translate(Vector3.left * Time.deltaTime * speed);

            //Destroy obstacles when they are off screen
            if (transform.position.x < leftBound)
            {
                Destroy(gameObject);

            }
        }
        else if (gameObject.CompareTag("Ground"))
        {
            if (gameManager.gameOn)
                transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

    }
}
