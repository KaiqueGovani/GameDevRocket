using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] hazard;
    public Transform[] spawnPoints;

    public float timeBetweenSpawns;
    float nextSpawnTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawnTime)
        {
            GameObject randomHazard = hazard[Random.Range(0, hazard.Length)];
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            Instantiate(randomHazard, randomSpawnPoint.position, randomSpawnPoint.rotation);
            nextSpawnTime = Time.time + timeBetweenSpawns;
        }
    }
}
