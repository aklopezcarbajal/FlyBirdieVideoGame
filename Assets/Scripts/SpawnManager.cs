using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private GameManager gameManager;

    private float spawnDelay = 2f;
    private float spawnInterval = 1.75f;
    public float spawnX;
    public float offset;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating("SpawnObject", spawnDelay, spawnInterval);
    }

    void Update()
    {
        
    }

    void SpawnObject()
    {
        if (gameManager.gameOn)
        {
            float offsetY = Random.Range(-offset, offset);
            Vector3 spawnPosition = new Vector3(spawnX, offsetY , 100);

            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        }
    }
}
