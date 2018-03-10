using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform groundCheck;
    public LayerMask whatIsGround;
    public bool grounded = false;
    public Transform target;            
    public float smoothing = 5f;
    private float rayonGround = 0.2f;
    Vector3 offset;
    public float sensitivity = 10f;
    public float rotationSpeed = 0.1f;
    public Transform personnage;
    public float movementTime = 1;
    Vector3 refPos;

    void Start()
    {
        // Calculate the initial offset.
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {

        grounded = Physics.CheckSphere(groundCheck.position, rayonGround, whatIsGround);
        // Create a postion the camera is aiming for based on the offset from the target.
        Vector3 targetCamPos = target.position + offset;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            

        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        }

    }

    private void Update()
    {
        /*var c = Camera.main.transform;
        c.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
        c.Rotate(-Input.GetAxis("Mouse Y") * sensitivity, 0, 0);
        c.Rotate(0, 0, -Input.GetAxis("QandE") * 90 * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
            Cursor.lockState = CursorLockMode.Locked;*/

        
        Quaternion newRotation = Quaternion.Slerp(transform.rotation, personnage.rotation, rotationSpeed * Time.deltaTime);
    }

}

