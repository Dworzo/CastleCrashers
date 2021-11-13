using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHP : MonoBehaviour
{
 
    public int maxHealth = 5;
    private int currentHealth;

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
}
