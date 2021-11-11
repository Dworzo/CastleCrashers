using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShooting : MonoBehaviour
{
    public GameObject bullet_spawn_point;
    public GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        float shotInput = Input.GetAxis("Fire1");

        if (shotInput == 1)
        {
            Instantiate(bullet, bullet_spawn_point.transform.position, Quaternion.identity);
        }

    }
}
