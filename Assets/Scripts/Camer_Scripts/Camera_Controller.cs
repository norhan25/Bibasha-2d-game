using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;                // This is the targt on which we have to add camera so that camera moves according to the movement of target
    public float camera_speed = 1f;
    public Vector3 offset;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition,camera_speed*Time.deltaTime);
        transform.position = smoothedPosition;

    }
}
