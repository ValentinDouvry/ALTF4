using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JacobController : MonoBehaviour {

    Rigidbody corps;
    public float speed = 10;
    bool seDeplace;
    public float forceSaut = 100;
    Animator animateur;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    private bool grounded = false;
    private float rayonGround = 0.2f;
    private float move;
    float camRayLength = 100f;
    Vector3 movement;
    int floorMask;
    




    private void Awake()
    {
        floorMask = LayerMask.GetMask("sol");
        corps = this.GetComponent<Rigidbody>();
        animateur = this.GetComponent<Animator>();
    }
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animateur.SetBool("grounded", false);
            //corps.AddForce(new Vector3(0, forceSaut));
            
        }



    }

    public void FixedUpdate()
    {
        var vel = corps.velocity;
        speed = vel.magnitude;
        animateur.SetFloat("speed", speed);
        grounded = Physics.CheckSphere(groundCheck.position, rayonGround, whatIsGround);
        animateur.SetBool("grounded", grounded);
        seDeplace = false;

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        //Move(h, v);
        //Turning();

        Vector3 direction = new Vector3();

        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction.z += 1f;
            seDeplace = true;
            
            
            
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction.z -= 1f;
            seDeplace = true;
            
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction.x -= 1f;
            seDeplace = true;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction.x += 1f;
            seDeplace = true;
            
        }  
        

        if (seDeplace)
        {
            speed = 100;
            corps.velocity = (direction * Time.deltaTime * speed);
            
        }
        /*else
        {
            corps.velocity = Vector3.zero;
            corps.angularVelocity = Vector3.zero;
        }*/
    }

    /*void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        corps.MovePosition(transform.position + movement);
    }*/

    /*void Turning()
    {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            

            // Set the player's rotation to this new rotation.
            corps.MoveRotation(newRotation);
        }
    }*/
}
