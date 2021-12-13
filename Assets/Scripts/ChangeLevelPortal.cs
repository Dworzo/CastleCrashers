using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevelPortal : MonoBehaviour
{
    public int level;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Triggered");
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Loading scene" + level);
            SceneManager.LoadScene(level);
        }  
    }
}
