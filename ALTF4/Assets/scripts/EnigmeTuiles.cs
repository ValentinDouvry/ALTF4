using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmeTuiles : MonoBehaviour {

    public bool estValableS = false, estValableP = false, actifS, actifP;
    Rigidbody corps;

    private void Awake()
    {
        corps = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start () {
		
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
}
