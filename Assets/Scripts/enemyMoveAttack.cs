using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMoveAttack : MonoBehaviour
{

    [SerializeField] private float enemyAttackDamage = 10f;
    [SerializeField] private float enemyAttackSpeed = 1f;

    public GameObject player;

    public float speed = 5f;

    private float rotationSpeed = 10.0f;
    private float canAttack;
    private Transform target;

    void Update()
    {
        //running towards player    
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.position += transform.forward * 5f * Time.deltaTime;

        if (target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            canAttack += Time.deltaTime;
        }

    }

        //enemy attack
    private void onCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (enemyAttackSpeed <= canAttack)
            {
                other.gameObject.GetComponent<playerHP>().updatePlayerHealth(-enemyAttackDamage);
                canAttack = 0f;
            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = null;
        }
    }
}