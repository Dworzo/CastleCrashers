using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRangedGOLD : MonoBehaviour
{
    [SerializeField] public int maxHealth = 5;
    private int currentHealth;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float startTimeBtwShots;
    public float aimingTime;
    //public float attackRange;

    public GameObject bulletSpawnPoint;
    public GameObject bullet;
    private Transform player;
    private Vector3 playerPosition;

    private float canAttack;
    private float timeBtwShots;
    private float rotationSpeed = 10f;
    private float distance;
    private bool isPreparingForShoot;
    private bool isPlayerVisible;
    private Vector3 retreatPosition;
    private Quaternion targetRotation;

    public NavMeshAgent agent;

    //private GameObject Line;
    private LineRenderer shootBeam;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerPosition = player.position;
        currentHealth = maxHealth;
        timeBtwShots = startTimeBtwShots;
        agent.stoppingDistance = stoppingDistance;
        isPreparingForShoot = false;
        isPlayerVisible = false;

        shootBeam = GetComponentInChildren<LineRenderer>();
        shootBeam.useWorldSpace = true;
        shootBeam.startColor = Color.yellow;
        shootBeam.endColor = Color.yellow;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isPreparingForShoot == false)
        {
            playerPosition = player.position;
        }

        canAttack += Time.deltaTime;
        distance = Vector3.Distance(transform.position, playerPosition);
        showShootBeam(gameObject.transform.position, transform.TransformDirection(Vector3.forward));
        //running towards player
        //transform.position += transform.forward * 5f * Time.deltaTime;

        //isInRange = distance > stoppingDistance && distance < retreatDistance;
        if (distance > stoppingDistance)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            agent.SetDestination(player.transform.position);
        }
        else
        {
            if (isPlayerVisible)
            {
                targetRotation = Quaternion.LookRotation(playerPosition - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
            if (timeBtwShots < canAttack && isPreparingForShoot == false && isPlayerVisible)
            {
                prepareForShoot();
                canAttack = 0f;
            }
        }
    }
    public virtual void Shoot()
    {
        Instantiate(bullet, bulletSpawnPoint.transform.position, gameObject.transform.rotation);
        ChangeColorOfBeam();
        isPreparingForShoot = false;
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
        // Create visisble raycast beam, which shows where the enemy is aiming.

        RaycastHit hit;
        int layerMask = 1 << 7;
        layerMask = ~layerMask;

        if (Physics.Raycast(position, direction, out hit, Mathf.Infinity, layerMask))
        {
            print(hit.collider.gameObject.name);
            print("pos:" + position);
            print("hit:" + hit.transform.position);
            shootBeam.SetPosition(1, position);
            shootBeam.SetPosition(0, new Vector3(hit.point.x, hit.point.y + 0.5f, hit.point.z));

            isPlayerVisible = (hit.collider.gameObject == player.gameObject);
        }

        if (Physics.Raycast(position, (player.transform.position - position).normalized, out hit, Mathf.Infinity, layerMask))
        {
            isPlayerVisible = (hit.collider.gameObject == player.gameObject);

            if (isPlayerVisible)
            {
                shootBeam.enabled = true;
            }
            else
            {
                shootBeam.enabled = false;
            }
        }
        else
        {
            shootBeam.enabled = false;
        }

        Debug.DrawLine(position, player.transform.position - position, Color.cyan);
    }

    private void prepareForShoot()
    {
        Vector3 fixedPosition = playerPosition;
        ChangeColorOfBeam();
        isPreparingForShoot = true;
        StartCoroutine(WaitBeforeShoot());

        IEnumerator WaitBeforeShoot()
        {

            yield return new WaitForSeconds(aimingTime);
            Shoot();
        }

    }

    public void OnDrawGizmosSelected()
    {
        //Stuff for debugging. Shows radiuses of stoppinsDistance and retreatDistance.

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, stoppingDistance);
        //Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void ChangeColorOfBeam()
    {
        if (shootBeam.startColor == Color.red)
        {
            shootBeam.startColor = Color.yellow;
            shootBeam.endColor = Color.yellow;
        }
        else if (shootBeam.startColor == Color.yellow)
        {
            shootBeam.startColor = Color.red;
            shootBeam.endColor = Color.red;
        }
    }
}