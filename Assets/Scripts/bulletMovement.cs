using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{
    public float bullet_speed = 35f;
    public int bulletDamage = 1;


    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Time.deltaTime * Vector3.forward * bullet_speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<enemyAttack>() != null)
            {
            other.GetComponent<enemyAttack>().dealDamage(bulletDamage);
        }
        Destroy(gameObject);
    }
}
