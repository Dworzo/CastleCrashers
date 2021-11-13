using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHP : MonoBehaviour
{
    public float maxHealth = 100f;
    public float playerHealth = 0f;

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
            player_Died();
        }
    }

    private void player_Died()
    {
        playerHealth = 0f;
        Debug.Log("Player Died");
    }
}
