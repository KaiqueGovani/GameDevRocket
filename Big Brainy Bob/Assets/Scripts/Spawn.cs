using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<Transform> spawnPointsStart;
    public List<Transform> spawnPoints;
    public int numberOfSpawns;

    public float timeBetweenSpawnsEasy;
    public float timeBetweenSpawnsHard;
    float nextSpawnTime;

    public GameObject SpikeBall;

    public Transform[] environmentSpawnPoints;
    public GameObject[] environmentPrefabs;

    public float timeBetweenEnvSpawns;
    float nextEnvSpawnTime;

    public float timeUntilMaxDifficulty;

    public GameObject CoinPrefab;
    public GameObject GenParent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextEnvSpawnTime)
        {
            for (int i = 0; i < environmentSpawnPoints.Length; i++)
            {
                GameObject randomPrefab = environmentPrefabs[Random.Range(0, environmentPrefabs.Length)];
                Instantiate(randomPrefab, environmentSpawnPoints[i].position, environmentSpawnPoints[i].rotation);
            }

            nextEnvSpawnTime = Time.time + timeBetweenEnvSpawns;
        }

        if (Time.time > nextSpawnTime)
        {
            Transform randomSpawnPoint;
            for(int i = 0; i < numberOfSpawns; i++)
            {
                randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
                Instantiate(SpikeBall, randomSpawnPoint.position, randomSpawnPoint.rotation);
                spawnPoints.Remove(randomSpawnPoint);
            }

            //Spawn a coin
            randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];   
            Instantiate(CoinPrefab, randomSpawnPoint.position, Quaternion.Euler(0, -90, 0));
            
            //SpawnCoin(randomSpawnPoint);



            spawnPoints.Clear();

            for (int i = 0; i < spawnPointsStart.Count; i++)
            {
                spawnPoints.Add(spawnPointsStart[i]);
            }

            nextSpawnTime = Time.time + Mathf.Lerp(timeBetweenSpawnsEasy, timeBetweenSpawnsHard, GetDifficultyPercent());
            Time.timeScale = Mathf.Lerp(1, 2, GetDifficultyPercent());
        }    
    }

    float GetDifficultyPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / timeUntilMaxDifficulty);
    }

    void SpawnCoin(Transform position)
    {
        GameObject parent = Instantiate(GenParent, position.position, position.rotation);
        GameObject child = Instantiate(CoinPrefab, parent.transform);
    }
}
