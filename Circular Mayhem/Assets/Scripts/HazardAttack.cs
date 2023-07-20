using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HazardAttack : Hazard
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Planet")
        {
            SceneManager.LoadScene("Game");
        }
        if(other.tag == "Player")
        {
            Destroy(gameObject);
        }
    
    }
}
