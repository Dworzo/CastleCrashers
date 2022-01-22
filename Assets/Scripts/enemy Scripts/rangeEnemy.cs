using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.AI;

public class rangeEnemy : EnemyEntity
{
    public int maxHealth = 5;
    private int currentHealth;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float startTimeBtwShots;
    public float attackRange;

    public GameObject bulletSpawnPoint;
    public GameObject bullet;
    private Transform player;

    private float canAttack;
    private float timeBtwShots;
    private float rotationSpeed = 10f;
    private float distance;
    private Vector3 retreatPosition;
    private Quaternion targetRotation;

    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
        timeBtwShots = startTimeBtwShots;
        agent.stoppingDistance = attackRange;
    }

    // Update is called once per frame
    void Update()
    {
        canAttack += Time.deltaTime;
        distance = Vector3.Distance(transform.position, player.position);


        if (distance > stoppingDistance)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            agent.SetDestination(player.transform.position);
        }
        else
        {
            targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            if (timeBtwShots < canAttack)
            {
                Shoot();
                canAttack = 0f;
            }
        }
    }

    public virtual void Shoot()
    {
        Instantiate(bullet, bulletSpawnPoint.transform.position, gameObject.transform.rotation);
        return;
    }

    public void dealDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            enemyDied();
        }
    }

    public void enemyDied()
    {
        gameObject.GetComponent<enemyLoot>().givePlayerGold();
        EnemyEntity.EnemiesLeft--;
        Destroy(gameObject);
    }
}