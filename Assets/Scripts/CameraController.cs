using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float x, y; 
    public float sensitivity = 2f; 
    public float distance = 5f; 
    public Vector2 xMinMax = new Vector2(-90f, 90f); 
    public Transform target; 

    private void LateUpdate()
    {
        //mouse inputs stuff
        x += Input.GetAxis("Mouse Y") * sensitivity * -1; 
        y += Input.GetAxis("Mouse X") * sensitivity;

        //vert rotation clamp
        x = Mathf.Clamp(x, xMinMax.x, xMinMax.y);

        //rotate
        transform.eulerAngles = new Vector3(x, y + 180, 0); 

        //camera positioning
        transform.position = target.position - transform.forward * distance;
    }
}

