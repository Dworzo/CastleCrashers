using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHP : MonoBehaviour
{
    public float maxHealth = 100f;
    public float playerHealth = 0f;
    public AudioSource clip;

    private void Start()
    {
        playerHealth = maxHealth;
        clip = gameObject.GetComponent<AudioSource>();
    }

    public void updatePlayerHealth(int damage)
    {
        playerHealth -= damage;
        clip.Play();

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
        SceneManager.LoadScene(1);
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
