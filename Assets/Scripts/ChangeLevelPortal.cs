using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevelPortal : MonoBehaviour
{
    public int level = -1;
    public float gameTime = 0f;
    private bool activated = false;

    void Update()
    {
        gameTime += Time.deltaTime;

        if (EnemyEntity.EnemiesLeft <= 0)
        {
            AudioSource m2 = gameObject.GetComponent<AudioSource>();
            m2.enabled = true;
            MeshRenderer m1 = gameObject.GetComponent<MeshRenderer>();
            m1.enabled = true;
            activated = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player" && activated == true)
        {
            if(level != -1)
                SceneManager.LoadScene(level);
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }  
    }
}
