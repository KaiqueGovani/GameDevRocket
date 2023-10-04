using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable

public class WaveManager : MonoBehaviour
{

    [System.Serializable]
    public class Wave
    {
        public int numberOfEnemies;
        public float timeBetweenSpawns;
        public GameObject[] enemies;
    }

    public Wave[] waves;
    public Transform[] spawnPoints;

    public float timeBetweenWaves;
    int currentWaveIndex = 0;
    Wave currentWave;


    UI ui;

    // Start is called before the first frame update
    void Start()
    {
        ui = FindObjectOfType<UI>();
        StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
    IEnumerator SpawnWaves()
    {
        for(int i = 0; i < waves.Length; i++)
        {
            currentWaveIndex = i;
            currentWave = waves[i];
            ui.SetWaveText(currentWaveIndex+1);
            for(int j = 0; j < currentWave.numberOfEnemies; j++)
            {
                GameObject randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
                Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                Instantiate(randomEnemy, randomSpawnPoint.position, randomSpawnPoint.rotation);
                yield return new WaitForSeconds(currentWave.timeBetweenSpawns);
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    

}
