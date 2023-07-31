using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    [SerializeField] private GameManager gm;

    public GameObject damageEffect;
    public GameObject coinEffect;

    AudioSource walkingSound;

    // Start is called before the first frame update
    void Start()
    {
        walkingSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        updateSoundPitch();
        float inputX = Input.GetAxisRaw("Horizontal");
        //transform.position += Vector3.right * inputX * Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x + speed * inputX * Time.deltaTime, -3, 3), transform.position.y, transform.position.z);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "SpikeBall")
        {
            gm.TakeDamage();
            SpawnEffect(damageEffect, gameObject);
            Destroy(other.gameObject);
        }

        if (other.tag == "Coin")
        {
            gm.CollectCoin();
            SpawnEffect(coinEffect, gameObject);
            Destroy(other.transform.parent.gameObject);
        }
    }

    void SpawnEffect(GameObject effect, GameObject target)
    {
        Instantiate(effect, target.transform.position, target.transform.rotation);
    }

    void updateSoundPitch()
    {
        walkingSound.pitch = Mathf.Lerp(2, 4, gm.GetDifficultyPercent());
    }
}
