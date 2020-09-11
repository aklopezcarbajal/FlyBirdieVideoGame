using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeatValue;
    
    void Start()
    {
        startPosition = transform.position;
        repeatValue = gameObject.GetComponent<BoxCollider2D>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startPosition.x - repeatValue)
        {
            transform.position = startPosition;
        }
        
    }
}
