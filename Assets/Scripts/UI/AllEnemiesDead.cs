using UnityEngine;
using System.Collections;

public class AllEnemiesDead : MonoBehaviour
{

    void Update()
    {
        print(GameObject.FindGameObjectsWithTag("Enemy").Length);

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            // Show 'Cleared' UI menu
            //here portal should get activated
        }
    }
}