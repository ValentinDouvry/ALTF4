using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JacobController : MonoBehaviour {

    Rigidbody corps;
    public int speed = 10;
    bool seDeplace;
    private void Awake()
    {
        corps = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        

    }

    public void FixedUpdate()
    {
        seDeplace = false;
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
            corps.velocity = (direction * Time.deltaTime * speed);
        }
        /*else
        {
            corps.velocity = Vector3.zero;
            corps.angularVelocity = Vector3.zero;
        }*/
    }
}
