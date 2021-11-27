using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    [SerializeField] private int enemyAttackDamage = 10;
    [SerializeField] private float enemyAttackSpeed = 1f;
    [SerializeField] public int maxHealth = 5;

    private int currentHealth;
    public float speed = 5f;
    private float canAttack;

    void Update()
    {
            canAttack += Time.deltaTime;
    }

    private void Start()
    {
        currentHealth = maxHealth;
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