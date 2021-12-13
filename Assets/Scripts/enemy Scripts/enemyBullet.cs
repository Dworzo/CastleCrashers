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

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<playerHP>().updatePlayerHealth(bulletDamage);
        }
        Destroy(gameObject);
    }
}

