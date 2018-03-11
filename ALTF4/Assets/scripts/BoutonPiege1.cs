using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonPiege1 : MonoBehaviour {

    GameObject piege;
    bool action = false;

    private void Awake()
    {
        piege = GameObject.Find("Piege1");
    }

    // Use this for initialization
    void Start() {}
	
	// Update is called once per frame
	void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            action = true;
        } else
        {
            action = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && action)
        {
            piege.GetComponent<Piege1>().setAction(true);
        }
    }
}
