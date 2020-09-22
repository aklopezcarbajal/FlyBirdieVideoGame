using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private float spawnDelay = 2f;
    private float spawnInterval = 1.5f;
    public float spawnX;
    public float spawnY;

    void Start()
    {
        InvokeRepeating("SpawnObject", spawnDelay, spawnInterval);
    }

    void Update()
    {
        
    }

    void SpawnObject()
    {
        Vector3 spawnPosition = new Vector3(spawnX, Random.Range(-spawnY, spawnY), 0);

        Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
    }
}
