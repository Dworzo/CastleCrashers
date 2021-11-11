using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private void Start() {

    }

    public float _playerSpeed = 10.0f;

    // Update is called once per frame
    void Update() {

        float horizontalInput = Input.GetAxis("Horizontal");
        float forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * _playerSpeed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * _playerSpeed * horizontalInput);
    }
}