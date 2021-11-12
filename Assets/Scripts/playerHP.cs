using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHP : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float playerHealth = 0f;

    private void Start()
    {
        playerHealth = maxHealth;
    }

    public void updatePlayerHealth(int damage)
    {
        playerHealth -= damage;

        if (playerHealth > maxHealth)
        {
            playerHealth = maxHealth;
        }
        else if (playerHealth <= 0f)
        {
            playerHealth = 0f;
            Debug.Log("Player Died");
        }
    }
}
