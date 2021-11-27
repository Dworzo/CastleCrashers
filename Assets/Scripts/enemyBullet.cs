using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    public float bulletSpeed = 20f;
    public int bulletDamage = 5;


    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Time.deltaTime * Vector3.forward * bulletSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<playerHP>() != null)
        {
            other.GetComponent<playerHP>().updatePlayerHealth(bulletDamage);
        }
    }
}

