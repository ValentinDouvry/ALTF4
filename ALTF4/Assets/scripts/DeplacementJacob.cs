using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementJacob : MonoBehaviour
{
    private Animator _animator;

    private CharacterController _characterController;

    public float speed = 5.0f;

    public Camera cam1, cam2, cam3;

    public float RotationSpeed = 240.0f;

    private float Gravity = 20.0f;

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


        corps2 = GameObject.Find("Grimace").GetComponent<Rigidbody>();
        
        
    }
    // Use this for initialization
    void Start()
    {
        //corps.isKinematic = true;

        /*cam1.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;*/
        cam1 = GameObject.Find("CameraJacob").GetComponent<Camera>();
        cam2 = GameObject.Find("CameraMort").GetComponent<Camera>();
        cam3 = GameObject.Find("CameraGrimace").GetComponent<Camera>();
        cam1.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;
        StartCoroutine(mort());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            action = true;
        }
        else
        {
            action = false;
        }
        if (!corps.isKinematic)
        {

            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
            if (x != 0 || z != 0 && !corps.isKinematic)
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
        if(collision.gameObject.tag == "Mortel")
        {
            //print("meurt");
            estMort = true;
            
        }
        if(collision.gameObject.tag == "button" && action)
        {
            animateur.SetBool("punch", true);
        }

        
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tuile")
        {
            GameObject tuileCourante = collision.gameObject;
            var a = tuileCourante.GetComponent<EnigmeTuiles>();
            if (a.estValableP)
            {
                a.setTuileSuivante(a.name);
            }
            else
            {
                mort();
            }
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
    }

    private void changerCamera()
    {
        cam1.enabled = !cam1.enabled;
        corps.isKinematic = !corps.isKinematic;
        print(gameObject.name + " changerCamera()");
    }

    public IEnumerator mort()
    {
        while (true)
        {
            if (estMort)
            {
                corps.isKinematic = true;
                cam1.enabled = false;
                cam2.enabled = true;
                yield return new WaitForSeconds(2);
                transform.position = new Vector3(0, 0, 0);
                corps.isKinematic = false;
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

}