using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementAllie : MonoBehaviour
{

    Rigidbody corps, corps2, cplat1, cplat2, cplat3;
    public bool estMort = false;
    Camera cam1, cam2;
    GameObject piege1, plat1, plat2, plat3;
    bool actifP = true, actifS = false, boutons = false, action = false;
    Animator animation;

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
        plat1 = GameObject.Find("Plateforme1");
        plat2 = GameObject.Find("Plateforme2");
        plat3 = GameObject.Find("Plateforme3");
        cplat1 = plat1.GetComponent<Rigidbody>();
        cplat2 = plat2.GetComponent<Rigidbody>();
        cplat3 = plat3.GetComponent<Rigidbody>();
        animation = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {}

    public void FixedUpdate()
    {
        Vector3 direction = new Vector3();

        if (Input.GetKey(KeyCode.UpArrow))
            direction.z += 1f;
        if (Input.GetKey(KeyCode.DownArrow))
            direction.z -= 1f;
        if (Input.GetKey(KeyCode.LeftArrow))
            direction.x -= 1f;
        if (Input.GetKey(KeyCode.RightArrow))
            direction.x += 1f;
        if (Input.GetKey(KeyCode.Space))
            direction.y += 1f;
        if (Input.GetKey(KeyCode.LeftShift))
            direction.y -= 1f;

        corps.velocity = (direction * Time.deltaTime * 100);
    }

    private IEnumerator OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Mortel")
        {
            corps.isKinematic = true;
            cam1.enabled = false;
            cam2.enabled = true;
            yield return new WaitForSeconds(2);
            transform.position = new Vector3(0, 0, 0);
            corps.isKinematic = false;
            cam1.enabled = true;
            cam2.enabled = false;
        }
    }

    private IEnumerator OnCollisionStay(Collision collision)
    {
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