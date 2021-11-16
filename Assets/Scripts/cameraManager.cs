using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{
    public GameObject player;
    public float cameraSpeed;
    public float offset_x;
    public float offset_y;
    public float offset_z;
    Vector3 offset;

    private void Start()
    {
 
    }
    void LateUpdate()
    {
        offset.Set(offset_x, offset_y, offset_z);
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, Time.deltaTime * cameraSpeed);
    }
}
