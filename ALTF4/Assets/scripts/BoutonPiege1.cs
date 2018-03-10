using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonPiege1 : MonoBehaviour {

    GameObject piege;

    private void Awake()
    {
        piege = GameObject.Find("Piege1");
    }

    // Use this for initialization
    void Start() {}
	
	// Update is called once per frame
	void Update() {}

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            piege.GetComponent<Piege1>().setAction(true);
        }
    }
}
