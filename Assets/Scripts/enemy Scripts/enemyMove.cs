using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    private float rotationSpeed = 10.0f;
    private Transform player;

    // Update is called once per frame
    void Update()
    {
        //running towards player

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.position += transform.forward * 5f * Time.deltaTime;
    }
}
