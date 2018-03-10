using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmeTuiles : MonoBehaviour {

    public bool estValableSK = false, estValableP = false, actifS, actifP;
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
        if (estValableSK)
        {
            
        }
        if (estValableP)
        {

        }
	}

    public void setEstValableSK(bool valeur)
    {
        estValableSK = valeur;
    }

    public void setEstValableP(bool valeur)
    {
        estValableP = valeur;
    }

    public bool getEstValableSK()
    {
        return estValableSK;
    }

    public bool getEstValableP()
    {
        return estValableP;
    }
}
