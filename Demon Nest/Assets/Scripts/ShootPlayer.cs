using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    public float timeBetweenShots;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    float nextShotTime;

    // Update is called once per frame
    void Update()
    {
        AutoShoot();
    }

    void AutoShoot()
    {
        if (Time.time > nextShotTime)
        {
            Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            nextShotTime = Time.time + timeBetweenShots;
        }
    }

}
