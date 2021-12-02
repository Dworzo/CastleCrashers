using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMove : MonoBehaviour
{
    private float rotationSpeed = 10.0f;
    private Transform player;
    public NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        //Navigating towards player
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent.SetDestination(player.transform.position);

        //running towards player
        //Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        //transform.position += transform.forward * 5f * Time.deltaTime;
    }
}
