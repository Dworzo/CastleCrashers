using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
 
    public int maxHealth = 1;
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
            Destroy(gameObject);
        }
    }
}
