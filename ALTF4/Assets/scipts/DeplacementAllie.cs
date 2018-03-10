using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementAllie : MonoBehaviour
{

    Rigidbody corps;
    public Vector3 speed;
    //public int speed = 10;
    float decelTime = 2;
    float currentDecelTime = 0;
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
        if (!seDeplace)
        {
            float interpolatinFactor = currentDecelTime / decelTime;
            Vector3 move = Vector3.Slerp(speed, Vector3.zero, interpolatinFactor);
            transform.position -= move;
            currentDecelTime += Time.deltaTime;
        }


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
            direction.x -= 1f; seDeplace = true;

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction.x += 1f; seDeplace = true;

        }

        if (Input.GetKey(KeyCode.Space))
        {
            direction.y += 1f; seDeplace = true;

        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            direction.y -= 1f; seDeplace = true;

        }
        corps.velocity = (direction * Time.deltaTime * 100);
        //corps.velocity = (direction * Time.deltaTime * speed);
    }
}
