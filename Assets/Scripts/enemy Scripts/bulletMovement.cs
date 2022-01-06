using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{
    public float bulletSpeed = 40f;
    public int bulletDamage = 2;


    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Time.deltaTime * Vector3.forward * bulletSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<enemyAttack>() != null)
        {
            other.GetComponent<enemyAttack>().dealDamage(bulletDamage);
        }
        else if (other.GetComponent<rangeEnemy>() != null){
            other.GetComponent<rangeEnemy>().dealDamage(bulletDamage);
        }
        Destroy(gameObject);
    }
}
