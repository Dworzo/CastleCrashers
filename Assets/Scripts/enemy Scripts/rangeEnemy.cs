using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeEnemy : MonoBehaviour
{
    [SerializeField] public int maxHealth = 5;
    private int currentHealth;

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float startTimeBtwShots;

    public GameObject bulletSpawnPoint;
    public GameObject bullet;
    public Transform player;

    private float canAttack;
    private float timeBtwShots;
    private float rotationSpeed = 10f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        canAttack += Time.deltaTime;

        //running towards player
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.position += transform.forward * 5f * Time.deltaTime;


        if (Vector3.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector3.Distance(transform.position, player.position) < stoppingDistance && Vector3.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector3.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (timeBtwShots < canAttack)
        {
            Instantiate(bullet, bulletSpawnPoint.transform.position, gameObject.transform.rotation);
            canAttack = 0f;
        }
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
        Destroy(gameObject);
    }

    


}