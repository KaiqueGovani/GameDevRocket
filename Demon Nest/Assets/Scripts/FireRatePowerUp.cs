using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRatePowerUp : MonoBehaviour
{
    public float newTimeBetweenShots;
    public float powerUpDuration;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.StartCoroutine(player.StartIncreaseFireRate(newTimeBetweenShots, powerUpDuration));
            Destroy(gameObject);
        }
    }
}
