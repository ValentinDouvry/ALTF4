using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouttonChoix : MonoBehaviour {


    GameObject chambreCrio, jacob;
    Animator animateur;
    Animator animateurJacob;
    Collision collision;
    GameObject porteDroite, porteGauche;
    Rigidbody rigidPorteDroite, rigidPorteGauche;
    public bool action = true;
    
    // Use this for initialization


    void Awake () {
        chambreCrio = GameObject.Find("anim_cryo_chamber");
        jacob = GameObject.Find("Jacob3.0");
        porteDroite = GameObject.Find("lvl1_grosseporte_02");
        porteGauche = GameObject.Find("lvl1_grosseporte_01");

        animateur = this.gameObject.GetComponent<Animator>();
        animateurJacob = jacob.gameObject.GetComponent<Animator>();
        rigidPorteDroite = porteDroite.gameObject.GetComponent<Rigidbody>();
        rigidPorteGauche = porteGauche.gameObject.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Start()
    {
        StartCoroutine(ouvrirPorte());
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

        else if (this.gameObject.name == "button_press" && collision.gameObject.tag == "Jacob" && Input.GetKey(KeyCode.E))
        {
            animateurJacob.SetBool("punch", true);
            //animateurJacob.SetBool("punch", false);
            //animateur.SetBool("appuye", true);
            action = true;
            ouvrirPorte();
            //("oui");
            //print("3");
        }



    }

    IEnumerator ouvrirPorte()
    {
        while (true)
        {
            if (action)
            {
                rigidPorteDroite.velocity = (new Vector3(0, 0, 200) * Time.deltaTime * 3);
                yield return new WaitForSeconds(2);
                rigidPorteDroite.velocity = Vector3.zero;
                rigidPorteDroite.angularVelocity = Vector3.zero;
                action = false;
            }
            yield return null;
        }
    }
}
