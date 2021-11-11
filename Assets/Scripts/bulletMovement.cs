using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{
    public float bullet_speed = 25f;
    public int bullet_damage = 1;


    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Time.deltaTime * Vector3.forward * bullet_speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<enemyHealth>() != null)
            {
            other.GetComponent<enemyHealth>().dealDamage(bullet_damage);
        }
        Destroy(gameObject);
    }
}
