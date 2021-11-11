using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float movementSpeed = 7.0f;
    private Rigidbody rigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCamera;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }


    // Update is called once per frame
    void Update() {


        //Player movement
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * movementSpeed;

        //Player rotation
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

       
        
        
    }


    private void FixedUpdate()
    {
        rigidbody.velocity = moveVelocity;
    }
}