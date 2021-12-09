using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet1 : MonoBehaviour
{
    public float bulletSpeed1 = 20f;
    public int bulletDamage1 = 5;


    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Time.deltaTime * Vector3.forward * bulletSpeed1);
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<playerHP>().updatePlayerHealth(bulletDamage1);
        }
    }
}

