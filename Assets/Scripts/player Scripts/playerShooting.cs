using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShooting : MonoBehaviour
{
    public GameObject bulletSpawnPoint;
    public GameObject bullet;
    float fireElapsedTime = 0f;
    public float fireDelay = 0.5f;

    public void Shoot()
    {
        Instantiate(bullet, bulletSpawnPoint.transform.position, gameObject.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
        float shotInput = Input.GetAxis("Fire1");

        if (shotInput == 1 && fireElapsedTime >= fireDelay)
        {
            fireElapsedTime = 0;
            Shoot();
        }
        fireElapsedTime += Time.deltaTime;
    }

    
}
