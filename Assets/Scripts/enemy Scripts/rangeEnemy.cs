using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class rangeEnemy : MonoBehaviour
{
    [SerializeField] public int maxHealth = 5;
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
     // private float aimingTime;
    private float rotationSpeed = 10f;
    private float distance;
    private Vector3 retreatPosition;
    private Quaternion targetRotation;

    public NavMeshAgent agent;

    public GameObject Line;
    public LineRenderer shootBeam;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
        timeBtwShots = startTimeBtwShots;
        agent.stoppingDistance = attackRange;

        shootBeam = GetComponentInChildren<LineRenderer>();
        shootBeam.useWorldSpace = true;
        shootBeam.startColor = Color.red;
        shootBeam.endColor = Color.red;

    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        canAttack += Time.deltaTime;
        distance = Vector3.Distance(transform.position, player.transform.position);
        showShootBeam(gameObject.transform.position, transform.TransformDirection(Vector3.forward));
        //running towards player
        //transform.position += transform.forward * 5f * Time.deltaTime;

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

        //if (distance > stoppingDistance)
        //{
        //    player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //    agent.SetDestination(player.transform.position);
        //    //transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        //}
        //else
        //    if (distance <= stoppingDistance && distance > retreatDistance)
        //    {
        //        //transform.position = this.transform.position;
        //        targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        //        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        //        if (timeBtwShots < canAttack)
        //            {
        //                Shoot();
        //                canAttack = 0f;
        //            }
        //    }
        //    else if (distance <= retreatDistance)
        //    {
        //        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //        //retreatPosition = Vector3.MoveTowards(transform.position, player.transform.position, transform.position - player.transform.position);
        //        agent.SetDestination(transform.position + transform.position - player.transform.position);
        //        //transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        //    }
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
        Destroy(gameObject);
    }

    public void showShootBeam(Vector3 position, Vector3 direction)
    {
        // Create visisble raycat beam, which shows where the enemy is aiming.

        RaycastHit hit;
        int layerMask = 1 << 7;
        layerMask = ~layerMask;

        if (Physics.Raycast(position, direction, out hit, Mathf.Infinity, layerMask))
        {
            print(hit.collider.gameObject.name);
            print("pos:" + position);
            print("hit:" + hit.transform.position);
            print(hit.point);
            shootBeam.SetPosition(1, position);
            shootBeam.SetPosition(0, new Vector3(hit.point.x, hit.point.y + 0.5f, hit.point.z));
            
        }
        Debug.DrawRay(position, direction * 100f, Color.cyan);
    }


}