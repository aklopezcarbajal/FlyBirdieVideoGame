using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private GameManager gameManager;

    private float spawnDelay = 2f;
    private float spawnInterval = 1.5f;
    public float spawnX;
    public float spawnY;

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
            Vector3 spawnPosition = new Vector3(spawnX, Random.Range(-spawnY, spawnY), 0);

            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        }
    }
}
