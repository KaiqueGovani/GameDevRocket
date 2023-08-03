using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Movement
    public float xSpeed;
    public float ySpeed = 7f;
    float screenCenterX;
    float screenCenterY;

    [SerializeField] private GameManager gm;

    // Effects
    public GameObject damageEffect;
    public GameObject coinEffect;

    // Audio
    AudioSource walkingSound;

    void Start() // Start is called before the first frame update
    {
        screenCenterX = Screen.width * 0.5f; // Get the center of the screen
        screenCenterY = Screen.height * 0.5f;
        walkingSound = GetComponent<AudioSource>();
    }

    void Update() // Update is called once per frame
    {
        updateSoundPitch(); // Update the pitch of the walking sound
        float inputX = Input.GetAxisRaw("Horizontal"); // Get the horizontal input

        if (Input.touchCount > 0)// Se houver algum toque na tela
        {
            Touch theTouch = Input.GetTouch(0); // Pega o primeiro toque
            Vector3 touchPosition = theTouch.position; // Pega a posição do toque
            if (touchPosition.x > screenCenterX) // Se o toque estiver na direita da tela
            {
                inputX = 1;
            }
            else // Se o toque estiver na esquerda da tela
            {
                inputX = -1;
            }
        }

        //transform.position += Vector3.right * inputX * Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x + xSpeed * inputX * Time.deltaTime, -3, 3), transform.position.y, transform.position.z);
        
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "SpikeBall") // If the player collides with a spike ball
        {
            gm.TakeDamage();
            SpawnEffect(damageEffect, gameObject);
            Destroy(other.gameObject);
        }

        if (other.tag == "Coin") // If the player collides with a coin
        {
            gm.CollectCoin();
            SpawnEffect(coinEffect, gameObject);
            Destroy(other.transform.parent.gameObject);
        }
    }

    void SpawnEffect(GameObject effect, GameObject target) // Spawn an effect at the target's position
    {
        Instantiate(effect, target.transform.position, target.transform.rotation);
    }

    void updateSoundPitch() // Update the pitch of the walking sound
    {
        walkingSound.pitch = Mathf.Lerp(2, 4, gm.GetDifficultyPercent());
    }
}
