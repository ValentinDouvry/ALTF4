using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouttonChoix : MonoBehaviour {


    GameObject chambreCrio;
	// Use this for initialization


	void Awake () {
        chambreCrio = GameObject.Find("anim_cryo_chamber");
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnCollisionStay(Collision collision)
    {
        if (this.gameObject.name == "button_press1" && collision.gameObject.tag == "Jacob" && Input.GetKey(KeyCode.E))
        {
            chambreCrio.GetComponent<Capsule>().setNumero(1);
            //print("1");
        }
        else if (this.gameObject.name == "button_press2" && collision.gameObject.tag == "Jacob" && Input.GetKey(KeyCode.E))
        {
            chambreCrio.GetComponent<Capsule>().setNumero(2);
            //print("2");
        }
        else if (this.gameObject.name == "button_press3" && collision.gameObject.tag == "Jacob" && Input.GetKey(KeyCode.E))
        {
            chambreCrio.GetComponent<Capsule>().setNumero(3);
            //print("3");
        }
    }
}
