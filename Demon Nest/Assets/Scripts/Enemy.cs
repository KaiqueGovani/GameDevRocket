using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamageable
{

    private NavMeshAgent agent;
    Transform target;

    public float minSpeed;
    public float maxSpeed;
    public float damage;

    public GameObject[] droppablePowerUps;
    public float powerUpChance;

    [SerializeReference]
    Health health = new Health();


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = Random.Range(minSpeed, maxSpeed);
        target = FindObjectOfType<Player>().transform;
        health.MaxHeal();
        //health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.position;
        UpdateRotationWhenInStopDistance();
    }



    public void TakeDamage(float damage)
    {
        health.TakeDamage(damage);
        if (health.GetHealth() <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        if (Random.Range(0, 100) < powerUpChance)
        {
            Instantiate(droppablePowerUps[Random.Range(0, droppablePowerUps.Length)], transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    public void TakeKnockback(Vector3 direction)
    {
        agent.velocity = direction * (agent.speed + agent.acceleration * 0.5f)/10 ;
        agent.isStopped = true;
        StartCoroutine(Knockback());
    }

    IEnumerator Knockback()
    {
        yield return new WaitForSeconds(0.5f);
        agent.isStopped = false;
    }

    void UpdateRotationWhenInStopDistance()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            RotateTowards(target);
        }
    }

    private void RotateTowards (Transform target) {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * agent.angularSpeed);
    }
}
