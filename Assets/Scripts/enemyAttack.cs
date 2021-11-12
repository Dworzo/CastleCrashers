using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    [SerializeField] private int enemyAttackDamage = 10;
    [SerializeField] private float enemyAttackSpeed = 1f;

    public float speed = 5f;

    private float canAttack;
    private Transform target;

    void Update()
    {


        if (target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            canAttack += Time.deltaTime;
        }

    }

        //enemy attack
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (enemyAttackSpeed <= canAttack)
            {
                other.gameObject.GetComponent<playerHP>().updatePlayerHealth(enemyAttackDamage);
                canAttack = 0f;
            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }
}