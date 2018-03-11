using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouttonChoix : MonoBehaviour {


    GameObject chambreCrio, jacob, ascenseur, grimace, pont, pont2;
    Animator animateur;
    Animator animateurJacob;
    Animator animPorte;
    Animator animPorteAscenseur;
    Animator grimaceAnim;
    Animator animPont;
    Animator animPont2;
    Collision collision;
    GameObject porte;
    Rigidbody rigidPorteDroite, rigidPorteGauche;
    public bool action = false;
    

    // Use this for initialization


    void Awake () {
        pont = GameObject.Find("pont");
        pont2 = GameObject.Find("pont (1)");
        chambreCrio = GameObject.Find("Lvl 1 anim_cryo_chamber");
        jacob = GameObject.Find("Jacob4.0");
        porte = GameObject.Find("Lvl 1 grossePorte_open");
        ascenseur = GameObject.Find("Lvl 1 ascenseur");
        grimace = GameObject.Find("Grimace2.0");
        animPont2 = pont2.gameObject.GetComponent<Animator>();
        animPont = pont.gameObject.GetComponent<Animator>();
        animPorte = porte.gameObject.GetComponent<Animator>();
        animateur = this.gameObject.GetComponent<Animator>();
        animateurJacob = jacob.gameObject.GetComponent<Animator>();
        animPorteAscenseur = ascenseur.gameObject.GetComponent<Animator>();
        grimaceAnim = grimace.gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Start()
    {
        
    }




    public void OnCollisionStay(Collision collision)
    {
        
        
        if (this.gameObject.name == "button_press (4)" && collision.gameObject.tag == "Jacob" && Input.GetKey(KeyCode.E))
        {
            animateurJacob.SetBool("punch", true);
            chambreCrio.GetComponent<Capsule>().setNumero(1);
            //yield return new WaitForSeconds(10);
            animateur.SetBool("appuye", true);

            //print("1");
        }
        else if (this.gameObject.name == "button_press (3)" && collision.gameObject.tag == "Jacob" && Input.GetKey(KeyCode.E))
        {
            animateurJacob.SetBool("punch", true);
            chambreCrio.GetComponent<Capsule>().setNumero(2);
            //yield return new WaitForSeconds(10);
            animateur.SetBool("appuye", true);
            //print("2");
        }
        else if (this.gameObject.name == "button_press (2)" && collision.gameObject.tag == "Jacob" && Input.GetKey(KeyCode.E))
        {
            animateurJacob.SetBool("punch", true);
            
            chambreCrio.GetComponent<Capsule>().setNumero(3);
            //yield return new WaitForSeconds(10);
            animateur.SetBool("appuye", true);
            //print("3");
        }

        else if (this.gameObject.name == "button_press (1)" && collision.gameObject.tag == "Jacob" && Input.GetKey(KeyCode.E))
        {
            animateurJacob.SetBool("punch", true);
            animPorteAscenseur.SetBool("ouverturePorte", true);
            //animateurJacob.SetBool("punch", false);
            //animateur.SetBool("appuye", true);
            //action = true;

            //("oui");
            //print("3");
        }
        

        else if (this.gameObject.name == "button_press" && collision.gameObject.tag == "Jacob" && Input.GetKey(KeyCode.E))
        {
            animateurJacob.SetBool("punch", true);
            animPorte.SetBool("ouverturePorte",true);
            //animateurJacob.SetBool("punch", false);
            //animateur.SetBool("appuye", true);
            //action = true;
            
            //("oui");
            //print("3");
        }
        else if (this.gameObject.name == "buttonAeration" && collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            grimaceAnim.SetBool("action", true);
            animPont2.SetBool("ouverturePont", true);
            animPont.SetBool("ouverturePont", true);
            //yield return new WaitForSeconds(10);
            //grimaceAnim.SetBool("action", false);
            //print("2");
        }



    }

    public void OnCollisionExit(Collision collision)
    {
        if(this.gameObject.name == "button_press (4)" && collision.gameObject.tag == "Jacob")
        {
            animateurJacob.SetBool("punch", false);
        }
        else if (this.gameObject.name == "button_press (3)" && collision.gameObject.tag == "Jacob")
        {
            animateurJacob.SetBool("punch", false);
        }
        else if (this.gameObject.name == "button_press (2)" && collision.gameObject.tag == "Jacob")
        {
            animateurJacob.SetBool("punch", false);
        }
        else if(this.gameObject.name == "button_press (1)" && collision.gameObject.tag == "Jacob")
        {
            animateurJacob.SetBool("punch", false);
        }
        else if (this.gameObject.name == "button_press " && collision.gameObject.tag == "Jacob")
        {
            animateurJacob.SetBool("punch", false);
        }
        else if (this.gameObject.name == "buttonAeration" && collision.gameObject.tag == "Player")
        {
            grimaceAnim.SetBool("action", false);
            
            //yield return new WaitForSeconds(10);
            //grimaceAnim.SetBool("action", false);
            //print("2");
        }
    }


}
