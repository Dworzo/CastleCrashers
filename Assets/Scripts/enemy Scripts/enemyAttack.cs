using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class enemyAttack : EnemyEntity
{
    [SerializeField] private int enemyAttackDamage = 10;
    [SerializeField] private float enemyAttackSpeed = 1f;
    [SerializeField] public int maxHealth = 5;

    private int currentHealth;
    private float canAttack;
    private float rotationSpeed;
    private Transform player;
    public UnityEngine.AI.NavMeshAgent agent;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        canAttack += Time.deltaTime;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent.SetDestination(player.transform.position);
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

    //enemy attack on collision
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (enemyAttackSpeed <= canAttack)
            {
                other.gameObject.GetComponent<playerHP>().updatePlayerHealth(enemyAttackDamage);
                canAttack = 0f;
            }
        }
    }
}