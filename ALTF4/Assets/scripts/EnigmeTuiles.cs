using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmeTuiles : MonoBehaviour {

    public bool estValable;
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
        if (estValable)
        {
            
        }
	}

    public void setEstValable(bool valeur)
    {
        estValable = valeur;
    }

    public bool getEstValable()
    {
        return estValable;
    }
}
