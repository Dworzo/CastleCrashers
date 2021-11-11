using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRotation : MonoBehaviour
{
    public Rigidbody rigidbody;
    public Camera camera;
    Vector3 mousePos;

  void Update()
   {
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 lookDir = mousePos - rigidbody.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x)* Mathf.Rad2Deg - 90f;
        //rigidbody.rotation = angle;

   }
}
