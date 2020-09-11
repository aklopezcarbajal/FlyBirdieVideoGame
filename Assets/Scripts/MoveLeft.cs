using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    public float speed;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 newPosition = transform.position + new Vector3(-1 *Time.deltaTime*speed);
        //transform.position = newPosition;

        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
