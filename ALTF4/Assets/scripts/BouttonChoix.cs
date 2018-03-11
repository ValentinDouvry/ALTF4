using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouttonChoix : MonoBehaviour {


    GameObject chambreCrio, jacob;
    Animator animateur;
    Animator animateurJacob;
    Collision collision;
    // Use this for initialization


    void Awake () {
        chambreCrio = GameObject.Find("anim_cryo_chamber");
        jacob = GameObject.Find("Jacob2.0");
        
        animateur = this.gameObject.GetComponent<Animator>();
        animateurJacob = jacob.gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Start()
    {
        //yield return StartCoroutine("OnCollisionStay");
    }




    public void OnCollisionStay(Collision collision)
    {
        
        
        if (this.gameObject.name == "button_press1" && collision.gameObject.tag == "Jacob" && Input.GetKey(KeyCode.E))
        {
            animateurJacob.SetBool("punch", true);
            chambreCrio.GetComponent<Capsule>().setNumero(1);
            //yield return new WaitForSeconds(10);
            animateur.SetBool("appuye", true);

            //print("1");
        }
        else if (this.gameObject.name == "button_press2" && collision.gameObject.tag == "Jacob" && Input.GetKey(KeyCode.E))
        {
            animateurJacob.SetBool("punch", true);
            chambreCrio.GetComponent<Capsule>().setNumero(2);
            //yield return new WaitForSeconds(10);
            animateur.SetBool("appuye", true);
            //print("2");
        }
        else if (this.gameObject.name == "button_press3" && collision.gameObject.tag == "Jacob" && Input.GetKey(KeyCode.E))
        {
            animateurJacob.SetBool("punch", true);
            chambreCrio.GetComponent<Capsule>().setNumero(3);
            //yield return new WaitForSeconds(10);
            animateur.SetBool("appuye", true);
            //print("3");
        }
            
        
        
    }
}
