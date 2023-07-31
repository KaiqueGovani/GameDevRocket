using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float speed;
    Spawn spawner;

    // Start is called before the first frame update
    void Start()
    {
        spawner = FindObjectOfType<Spawn>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;    
    }
}
