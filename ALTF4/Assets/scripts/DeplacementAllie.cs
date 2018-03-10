using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementAllie : MonoBehaviour
{

    Rigidbody corps, corps2;
    public Vector3 speed;
    //public int speed = 10;
    //bool seDeplace;
    public bool estMort = false;
    Camera cam1, cam2;
    GameObject piege1;
    bool actifP = true, actifS = false;

    private void Awake()
    {
        corps = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start()
    {
        cam1 = Camera.main;
        cam2 = GameObject.Find("CameraMort").GetComponent<Camera>();
        cam1.enabled = true;
        cam2.enabled = false;
        piege1 = GameObject.Find("Piege1");
        corps2 = piege1.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (!seDeplace)
        {
            float interpolatinFactor = currentDecelTime / decelTime;
            Vector3 move = Vector3.Slerp(speed, Vector3.zero, interpolatinFactor);
            transform.position -= move;
            currentDecelTime += Time.deltaTime;
        }
        */
    }

    public void FixedUpdate()
    {
        //seDeplace = false;
        Vector3 direction = new Vector3();

        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction.z += 1f;
            //seDeplace = true;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction.z -= 1f;
            //seDeplace = true;

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction.x -= 1f;
            //seDeplace = true;

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction.x += 1f;
            //seDeplace = true;

        }

        if (Input.GetKey(KeyCode.Space))
        {
            direction.y += 1f;
            //seDeplace = true;

        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            direction.y -= 1f;
            //seDeplace = true;

        }

        corps.velocity = (direction * Time.deltaTime * 100);
    }

    private IEnumerator OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Mortel")
        {
            cam1.enabled = false;
            cam2.enabled = true;
            yield return new WaitForSeconds(2);
            transform.position = new Vector3(0, 0, 0);
            finMort = true;
        }
    }

    private IEnumerator OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Action" && Input.GetKey(KeyCode.E))
        {
            corps2.AddForce(0, 0, 200);
            yield return new WaitForSeconds(2);
            corps2.velocity = Vector3.zero;
            corps2.angularVelocity = Vector3.zero;
        }
        if (collision.gameObject.tag == "Tuile")
        {
            GameObject tuileCourante = collision.gameObject;
            var a = tuileCourante.GetComponent<EnigmeTuiles>();
            /*if (a.getEstValableP())
            {
                actifP = true;
                if(actifP && actifS)
                {
                    setTuileSuivante(a.name);
                }
            } else
            {
                cam1.enabled = false;
                cam2.enabled = true;
                yield return new WaitForSeconds(2);
                transform.position = new Vector3(0, 0, 0);
            }*/
            if (a.getEstValableS())
            {
                actifS = true;
                if (actifP && actifS)
                {
                    setTuileSuivante(a.name);
                }
            }
            else
            {
                cam1.enabled = false;
                cam2.enabled = true;
                yield return new WaitForSeconds(2);
                transform.position = new Vector3(0, 0, 0);
            }

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Mortel")
        {
            cam1.enabled = true;
            cam2.enabled = false;
        }
        if (collision.gameObject.tag == "Tuile")
        {
            GameObject tuileCourante = collision.gameObject;
            var a = tuileCourante.GetComponent<EnigmeTuiles>();
            /*if (a.estValableP)
            {
                a.setEstValableP(false);
                actifP = false;
            } else
            {
                cam1.enabled = true;
                cam2.enabled = false;
            }*/
            if (a.estValableS)
            {
                a.setEstValableS(false);
                actifS = false;
            }
            else
            {
                cam1.enabled = true;
                cam2.enabled = false;
            }

        }
    }

    private void setTuileSuivante(string tuileCourante)
    {
        /*
        if(tuileCourante == "ParcoursP1")
        {
            GameObject tuile = GameObject.Find("ParcoursP2");
            var a = tuile.GetComponent<EnigmeTuiles>();
            a.setEstValableP(true);
        }
        if (tuileCourante == "ParcoursP2")
        {
            GameObject tuile = GameObject.Find("ParcoursP3");
            var a = tuile.GetComponent<EnigmeTuiles>();
            a.setEstValableP(true);
        }
        if (tuileCourante == "ParcoursP3")
        {
            GameObject tuile = GameObject.Find("ParcoursP4");
            var a = tuile.GetComponent<EnigmeTuiles>();
            a.setEstValableP(true);
        }
        if (tuileCourante == "ParcoursP4")
        {
            GameObject tuile = GameObject.Find("ParcoursP5");
            var a = tuile.GetComponent<EnigmeTuiles>();
            a.setEstValableP(true);
        }
        if (tuileCourante == "ParcoursP5")
        {
            GameObject tuile = GameObject.Find("ParcoursP6");
            var a = tuile.GetComponent<EnigmeTuiles>();
            a.setEstValableP(true);
        }*/
        if (tuileCourante == "ParcoursS1")
        {
            GameObject tuile = GameObject.Find("ParcoursS2");
            var a = tuile.GetComponent<EnigmeTuiles>();
            a.setEstValableS(true);
        }
        if (tuileCourante == "ParcoursS2")
        {
            GameObject tuile = GameObject.Find("ParcoursS3");
            var a = tuile.GetComponent<EnigmeTuiles>();
            a.setEstValableS(true);
        }
        if (tuileCourante == "ParcoursS3")
        {
            GameObject tuile = GameObject.Find("ParcoursS4");
            var a = tuile.GetComponent<EnigmeTuiles>();
            a.setEstValableS(true);
        }
        if (tuileCourante == "ParcoursS4")
        {
            GameObject tuile = GameObject.Find("ParcoursS5");
            var a = tuile.GetComponent<EnigmeTuiles>();
            a.setEstValableS(true);
        }
        if (tuileCourante == "ParcoursS5")
        {
            GameObject tuile = GameObject.Find("ParcoursS6");
            var a = tuile.GetComponent<EnigmeTuiles>();
            a.setEstValableS(true);
        }
    }
}