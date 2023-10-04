using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public float damage;

    public enum OwnerTag { 
        Player, 
        Enemy 
    }

    public OwnerTag ownerTag;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(ownerTag.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    } 

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag(ownerTag.ToString()))
        {
            return;
        }
        
        if (other.gameObject.GetComponent<IDamageable>() != null)
        {
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
            damageable.TakeDamage(damage);
            Destroy(gameObject);
        }
    
    }


}
