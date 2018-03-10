using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plateformes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y > 10.9 && 11 > transform.position.y )
        {
            GetComponent<Renderer>().material.color = Color.green;
        } else
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
	}
}
