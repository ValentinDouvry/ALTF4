﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementJacob : MonoBehaviour
{
    private Animator _animator;

    private CharacterController _characterController;

    public float speed = 5.0f;


    public float RotationSpeed = 240.0f;

    private float Gravity = 20.0f;

    private Vector3 _moveDir = Vector3.zero;
    /*References*/
    Animator animateur;
    Rigidbody corps;
    /*-----------------*/

    /*Check Ground*/
    public Transform groundCheck;
    public LayerMask whatIsGround;
    private bool grounded = false;
    private float rayonGround = 0.4f;
    /*----------------*/
    bool seDeplace;
    public float X;
    public float Z;
    public float forceSaut = 100;



    // Use this for initialization
    void Start()
    {
        animateur = GetComponent<Animator>();
        corps = GetComponent<Rigidbody>();
        StartCoroutine(sauter());
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        if(x!=0 || z !=0)
        {
            seDeplace = true;
        }
        X = x;
        Z = z;
        var vel = corps.velocity;
        speed = vel.magnitude;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
        


        animateur.SetBool("seDeplace", seDeplace);

        grounded = Physics.CheckSphere(groundCheck.position, rayonGround, whatIsGround);
        animateur.SetBool("grounded", grounded);
        seDeplace = false;  

        
        
    }
    

    IEnumerator sauter()
    {
        while(true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && grounded)
            {
                animateur.SetBool("grounded", false);
                yield return new WaitForSeconds(0.28f);
                corps.AddForce(new Vector3(0, forceSaut));

            }
            yield return null;
        }
        
    }

}
