using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmeTuiles : MonoBehaviour
{

    public bool estValableS = false, estValableP = false;
    public static EnigmeTuiles actifS, actifP;
    public bool lockActive = false;
    Rigidbody corps;
    private bool resetNextFrame = false;
    public MeshRenderer mesh;


    private void Awake()
    {
        corps = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshRenderer>();
    }
    // Use this for initialization
    void Start()
    {

    }

    public void setTuileSuivante()
    {
        resetNextFrame = true;
        if (name == "ParcoursS1")
        {
            GameObject tuile = GameObject.Find("ParcoursS2");
            var a = tuile.GetComponent<EnigmeTuiles>();
            a.setEstValableS(true);
        }
        if (name == "ParcoursS2")
        {
            GameObject tuile = GameObject.Find("ParcoursS3");
            var a = tuile.GetComponent<EnigmeTuiles>();
            a.setEstValableS(true);
        }
        if (name == "ParcoursS3")
        {
            GameObject tuile = GameObject.Find("ParcoursS4");
            var a = tuile.GetComponent<EnigmeTuiles>();
            a.setEstValableS(true);
        }
        if (name == "ParcoursS4")
        {
            GameObject tuile = GameObject.Find("ParcoursS5");
            var a = tuile.GetComponent<EnigmeTuiles>();
            a.setEstValableS(true);
        }
        if (name == "ParcoursS5")
        {
            GameObject tuile = GameObject.Find("ParcoursS6");
            var a = tuile.GetComponent<EnigmeTuiles>();
            a.setEstValableS(true);
        }
        if (name == "ParcoursP1")
        {
            GameObject tuile = GameObject.Find("ParcoursP2");
            var a = tuile.GetComponent<EnigmeTuiles>();
            a.setEstValableP(true);
        }
        if (name == "ParcoursP2")
        {
            GameObject tuile = GameObject.Find("ParcoursP3");
            var a = tuile.GetComponent<EnigmeTuiles>();
            a.setEstValableP(true);
        }
        if (name == "ParcoursP3")
        {
            GameObject tuile = GameObject.Find("ParcoursP4");
            var a = tuile.GetComponent<EnigmeTuiles>();
            a.setEstValableP(true);
        }
        if (name == "ParcoursP4")
        {
            GameObject tuile = GameObject.Find("ParcoursP5");
            var a = tuile.GetComponent<EnigmeTuiles>();
            a.setEstValableP(true);
        }
        if (name == "ParcoursP5")
        {
            GameObject tuile = GameObject.Find("ParcoursP6");
            var a = tuile.GetComponent<EnigmeTuiles>();
            a.setEstValableP(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (resetNextFrame)
        {
            actifP = null;
            actifS = null;
            resetNextFrame = false;
        }
        if (estValableS)
        {
            /*
            texture = GetComponent
            mesh.material.mainTexture = 
            */
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            if (estValableP)
            {
                GetComponent<Renderer>().material.color = Color.green;
            }
            else if (lockActive)
            {
                GetComponent<Renderer>().material.color = Color.cyan;
            }
            else
            {
                GetComponent<Renderer>().material.color = Color.white;

            }
        }

    }

    public void setEstValableS(bool valeur)
    {
        estValableS = valeur;
    }

    public void setEstValableP(bool valeur)
    {
        estValableP = valeur;
    }

    public bool getEstValableS()
    {
        return estValableS;
    }

    public bool getEstValableP()
    {
        return estValableP;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (lockActive)
        {
            return;
        }
        if (collision.gameObject.name == "Grimace2.0")
        {
            if (estValableS)
            {
                actifS = this;
                if (actifP && actifS)
                {
                    lockActive = true;
                    actifS.setTuileSuivante();
                    actifP.setTuileSuivante();
                }
            }
            else
            {
                collision.gameObject.GetComponent<DeplacementAllie>().estMort = true;
            }

        }
        if (collision.gameObject.tag == "Jacob4.0")
        {

            if (estValableP)
            {
                actifP = this;
                if (actifP && actifS)
                {
                    lockActive = true;
                    actifS.setTuileSuivante();
                    actifP.setTuileSuivante();
                }
            }
            else
            {

                collision.gameObject.GetComponent<DeplacementJacob>().estMort = true;
            }
        }

    }

    public void OnCollisionExit(Collision collision)
    {
        if (lockActive)
        {
            return;
        }
        if (collision.gameObject.tag == "Player")
        {
            if (actifS)
            {
                actifS = null;

            }

        }
        if (collision.gameObject.tag == "Jacob")
        {

            if (actifP)
            {
                actifP = null;

            }

        }

    }
}

