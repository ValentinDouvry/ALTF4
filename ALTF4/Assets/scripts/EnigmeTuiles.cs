using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmeTuiles : MonoBehaviour {

    public bool estValableS = false, estValableP = false, actifS = false, actifP = false;
    Rigidbody corps;

    private void Awake()
    {
        corps = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start () {
		
	}

    public void setTuileSuivante(string tuileCourante)
    {
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
        if (tuileCourante == "ParcoursP1")
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
        }
    }

    // Update is called once per frame
    void Update () {
        if (estValableS)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        } else
        {
            if (estValableP)
            {
                GetComponent<Renderer>().material.color = Color.green;
            } else
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
        if (collision.gameObject.tag == "Player")
        {
            if (estValableS)
            {
                actifS = true;
                if (actifP && actifS)
                {
                    setTuileSuivante(name);
                }
            }
            else
            {

                collision.gameObject.GetComponent<DeplacementAllie>().mort();
            }

        }
        if (collision.gameObject.tag == "Jacob")
        {
            
            if (estValableP)
            {
                actifP = true;
                if (actifP && actifS)
                {
                    setTuileSuivante(name);
                }
            }
            else
            {

                collision.gameObject.GetComponent<DeplacementJacob>().mort();
            }
        }

    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (actifS)
            {
                actifS = false;
                
            }            

        }
        if (collision.gameObject.tag == "Jacob")
        {

            if (actifP)
            {
                actifP = false;
               
            }
            
        }

    }
}

