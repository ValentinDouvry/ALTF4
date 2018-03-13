using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouttonChoix : MonoBehaviour {


    GameObject chambreCrio, jacob, ascenseur, grimace, pont, pont2, ascenseurBlock, crio1;
    Animator animateur;
    Animator animateurJacob;
    Animator animPorte;
    Animator animPorteAscenseur;
    Animator grimaceAnim;
    Animator animPont;
    Animator animPont2;
    Collision collision;
    BoxCollider blockAscenseur;
    GameObject porte;
    Rigidbody rigidPorteDroite, rigidPorteGauche;
    public GameObject barreau1, barreau2, barreau3, barreau4, barreau5, barreau6, barreau7, barreau8, barreau9, barreau10, barreau11, barreau12, barreau13, barreau14, barreau15, barreau16, barreau17, barreau18, barreau19, barreau20, barreau21, barreau22;
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
        ascenseurBlock = GameObject.Find("ascenseurBlock");
        crio1 = GameObject.Find("collider_capsule_01");
        blockAscenseur = ascenseurBlock.GetComponent<BoxCollider>();
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
            crio1.GetComponent<MeshCollider>().enabled = false;

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
            blockAscenseur.enabled = false;

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
            barreau1.GetComponent<MeshRenderer>().enabled = false;
            barreau1.GetComponent<CapsuleCollider>().enabled = false;
            barreau2.GetComponent<MeshRenderer>().enabled = false;
            barreau2.GetComponent<CapsuleCollider>().enabled = false;
            barreau3.GetComponent<MeshRenderer>().enabled = false;
            barreau3.GetComponent<CapsuleCollider>().enabled = false;
            barreau4.GetComponent<MeshRenderer>().enabled = false;
            barreau4.GetComponent<CapsuleCollider>().enabled = false;
            barreau5.GetComponent<MeshRenderer>().enabled = false;
            barreau5.GetComponent<CapsuleCollider>().enabled = false;
            barreau6.GetComponent<MeshRenderer>().enabled = false;
            barreau6.GetComponent<CapsuleCollider>().enabled = false;
            barreau7.GetComponent<MeshRenderer>().enabled = false;
            barreau7.GetComponent<CapsuleCollider>().enabled = false;
            barreau8.GetComponent<MeshRenderer>().enabled = false;
            barreau8.GetComponent<CapsuleCollider>().enabled = false;
            barreau9.GetComponent<MeshRenderer>().enabled = false;
            barreau9.GetComponent<CapsuleCollider>().enabled = false;
            barreau10.GetComponent<MeshRenderer>().enabled = false;
            barreau10.GetComponent<CapsuleCollider>().enabled = false;
            barreau11.GetComponent<MeshRenderer>().enabled = false;
            barreau11.GetComponent<CapsuleCollider>().enabled = false;
            barreau12.GetComponent<MeshRenderer>().enabled = false;
            barreau12.GetComponent<CapsuleCollider>().enabled = false;
            barreau13.GetComponent<MeshRenderer>().enabled = false;
            barreau13.GetComponent<CapsuleCollider>().enabled = false;
            barreau14.GetComponent<MeshRenderer>().enabled = false;
            barreau14.GetComponent<CapsuleCollider>().enabled = false;
            barreau15.GetComponent<MeshRenderer>().enabled = false;
            barreau15.GetComponent<CapsuleCollider>().enabled = false;
            barreau16.GetComponent<MeshRenderer>().enabled = false;
            barreau16.GetComponent<CapsuleCollider>().enabled = false;
            barreau17.GetComponent<MeshRenderer>().enabled = false;
            barreau17.GetComponent<CapsuleCollider>().enabled = false;
            barreau18.GetComponent<MeshRenderer>().enabled = false;
            barreau18.GetComponent<CapsuleCollider>().enabled = false;
            barreau19.GetComponent<MeshRenderer>().enabled = false;
            barreau19.GetComponent<CapsuleCollider>().enabled = false;
            barreau20.GetComponent<MeshRenderer>().enabled = false;
            barreau20.GetComponent<CapsuleCollider>().enabled = false;
            barreau21.GetComponent<MeshRenderer>().enabled = false;
            barreau21.GetComponent<CapsuleCollider>().enabled = false;
            barreau22.GetComponent<MeshRenderer>().enabled = false;
            barreau22.GetComponent<CapsuleCollider>().enabled = false;
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
