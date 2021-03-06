﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementJacob : MonoBehaviour
{
    private Animator _animator;
    public GameObject grimace;
    public bool finLevel1 = false;


    private CharacterController _characterController;

    public float speed = 5.0f;

    public Camera cam1, cam2, cam3,cam4;
    public GameObject barreau1, barreau2, barreau3, barreau4;
    public MeshRenderer rend1, rend2, rend3, rend4;
    public CapsuleCollider caps1, caps2, caps3, caps4;

    public float RotationSpeed = 240.0f;

    private float Gravity = 20.0f;
    public AudioClip music;
    private AudioSource source;
    private bool checkpointlvl2 = false;
    private Vector3 _moveDir = Vector3.zero;
    /*References*/
    Animator animateur;
    Rigidbody corps, corps2;

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
    public bool aSaute;
    bool action = false;
    public bool estMort = false;
    bool actifP = false;


    private void Awake()
    {
        corps = GetComponent<Rigidbody>();
        animateur = GetComponent<Animator>();
        source = this.GetComponent<AudioSource>();


        corps2 = GameObject.Find("Grimace2.0").GetComponent<Rigidbody>();
        
        
    }
    // Use this for initialization
    void Start()
    {
        //corps.isKinematic = true;

        /*cam1.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;*/
        //cam1 = GameObject.Find("CameraJacob").GetComponent<Camera>();
        //cam2 = GameObject.Find("CameraMort").GetComponent<Camera>();
        //cam3 = GameObject.Find("CameraGrimace").GetComponent<Camera>();
        cam1.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;
        cam4.enabled = false;
        StartCoroutine(mort());
    }

    // Update is called once per frame
    void Update()
    {

        if (source != null && !source.isPlaying)
        {
            source.PlayOneShot(music);
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            action = true;
        }
        else
        {
            action = false;
        }
        if (cam1.enabled)
        {
            //print("oui");
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
            if (x != 0 || z != 0)
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


            if (Input.GetKeyDown(KeyCode.Space) && grounded)
            {
                print("space");
                animateur.SetBool("grounded", false);
                //aSaute = true;
                //yield return new WaitForSeconds(0.28f);
                corps.AddForce(new Vector3(0, forceSaut));



            }
            
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            changerCamera();
        }
    }
    

    IEnumerator sauter()
    {
        aSaute = false;
        while(true)
        {
            if (action && grounded)
            {
                print("space");
                animateur.SetBool("grounded", false);
                //aSaute = true;
                //yield return new WaitForSeconds(0.28f);
                corps.AddForce(new Vector3(0, forceSaut));
                //aSaute = false;

            }
            yield return null;
        }
        
    }

    public void OnCollisionStay(Collision collision)
    {
        
        if(collision.gameObject.tag == "button" && action)
        {
            animateur.SetBool("punch", true);
        }
        if (collision.gameObject.tag == "Mortel")
        {
            //print("meurt");
            estMort = true;

        }

    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tuile")
        {
            GameObject tuileCourante = collision.gameObject;
            var a = tuileCourante.GetComponent<EnigmeTuiles>();
            if (!a.estValableP)
            {
                estMort = true;
            }
            
            
        }

        if(collision.gameObject.tag == "ascenseur")
        {
            this.transform.position = new Vector3(-14.26f, 2.375f, -12.46f);
            transform.Rotate(new Vector3(0, 90, 0));
            grimace.transform.position = new Vector3(-13.96f,4.71f,-12.68f);
            corps2.transform.Rotate(new Vector3(0, 90, 0));
            finLevel1 = true;
            grimace.GetComponent<DeplacementAllie>().level1 = true;
        }
        if (collision.gameObject.tag == "Finish")
        {
            cam1.enabled = false;
            cam2.enabled = false;
            cam3.enabled = false;
            cam4.enabled = true;
        }

        if(collision.gameObject.tag == "checkpointLvl2")
        {
            checkpointlvl2 = true;
        }
        



    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Tuile")
        {
            GameObject tuileCourante = collision.gameObject;
            var a = tuileCourante.GetComponent<EnigmeTuiles>();
           
            a.setEstValableP(false);
            actifP = false;
            
        }
        if (collision.gameObject.tag == "button")
        {
            animateur.SetBool("punch", false);
        }
    }

    private void changerCamera()
    {
        cam1.enabled = !cam1.enabled;
        //corps.isKinematic = !corps.isKinematic;
        print(gameObject.name + " changerCamera()");
    }

    public IEnumerator mort()
    {
        while (true)
        {
            if (estMort)
            {

                //corps.isKinematic = true;
                cam1.enabled = false;
                cam2.enabled = true;
                yield return new WaitForSeconds(2);
                if(finLevel1)
                {
                    this.transform.position = new Vector3(-14.26f, 2.375f, -12.46f);
                    transform.Rotate(new Vector3(0, 180, 0));
                    grimace.transform.position = new Vector3(-13.96f, 4.71f, -12.68f);
                    corps2.transform.Rotate(new Vector3(0, 90, 0));
                }
                else if(checkpointlvl2)
                {
                    this.transform.position = new Vector3(9.736f, 2.42f, -12.22f);
                    grimace.transform.position = new Vector3(6.625f, 2.956f, -12.998f);
                }
                else
                {
                    transform.position = new Vector3(20.209f, 0.837f, -2.73f);
                    transform.Rotate(new Vector3(0, -90, 0));
                    grimace.transform.position = new Vector3(-1.656f, 0.589f, -0.55f);
                }
                
                //corps.isKinematic = false;
                cam1.enabled = true;
                cam2.enabled = false;
                estMort = false;
            }
            yield return null;
        }
    }

    public bool getActifP()
    {
        return actifP;
    }

    private void OnTriggerEnter(Collider other)
    {
        //print("oui");
        if(other.gameObject.tag == "debutNiveau")
        {
            
            rend1 = barreau1.GetComponent<MeshRenderer>();
            rend2 = barreau2.GetComponent<MeshRenderer>();
            rend3 = barreau3.GetComponent<MeshRenderer>();
            rend4 = barreau4.GetComponent<MeshRenderer>();

            rend1.enabled = false;
            rend2.enabled = false;
            rend3.enabled = false;
            rend4.enabled = false;

            caps1 = barreau1.GetComponent<CapsuleCollider>();
            caps2 = barreau2.GetComponent<CapsuleCollider>();
            caps3 = barreau3.GetComponent<CapsuleCollider>();
            caps4 = barreau4.GetComponent<CapsuleCollider>();

            caps1.enabled = false;
            caps2.enabled = false;
            caps3.enabled = false;
            caps4.enabled = false;

        }
    }

}