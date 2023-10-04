using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#pragma warning disable

public class Player : MonoBehaviour, IDamageable
{
    // Movement
    public float speed;
    private Rigidbody rb;
    private Vector3 moveVelocity;

    // Animation
    public Animator anim;
    
    // Camera
    private Camera mainCamera;
    UI ui;

    // Shooting
    public GameObject bulletPrefab;
    public Transform shotPoint;
    public float timeBetweenShots;
    float baseTimeBetweenShots;
    float nextShotTime;

    // Health
    [SerializeReference]
    Health health = new Health();


    void Start()
    {
        ui = FindObjectOfType<UI>();
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        health.MaxHeal();
        baseTimeBetweenShots = timeBetweenShots;
    }

    void Update()
    {
        Move();
        Rotate();
        Shoot();
    }


    void Move()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (moveInput == Vector3.zero) anim.SetBool("isRunning", false);
        else anim.SetBool("isRunning", true);
        

        moveVelocity = moveInput.normalized * speed;
    }

    void Rotate()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }

    void Shoot()
    {
        if (Time.time > nextShotTime)
        {
            if(Input.GetMouseButton(0)){
                Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);
                nextShotTime = Time.time + timeBetweenShots;
            }
        }
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    public void TakeDamage(float damage)
    {
        health.TakeDamage(damage);
        ui.UpdateHealhBar(health.GetHealth());
        if (health.GetHealth() <= 0)
        {
            SceneManager.LoadScene("Game");
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            TakeDamage(enemy.damage);
            enemy.TakeKnockback(enemy.transform.position - transform.position);
        }
    }

    public void Heal(float healAmount)
    {
        health.Heal(healAmount);
        ui.UpdateHealhBar(health.GetHealth());
    }

    public IEnumerator StartIncreaseFireRate(float newRateOfFire, float powerUpDuration)
    {
        timeBetweenShots = newRateOfFire;
        yield return new WaitForSeconds(powerUpDuration);
        timeBetweenShots = baseTimeBetweenShots;
    }

}
