using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour {

    private Animator animateur;
    public int numero = 0;
    public bool ouvrir = false;
    public bool premiereOuverture = true;
	// Use this for initialization
	void Awake () {
        animateur = this.gameObject.GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Start()
    {
        StartCoroutine(setAction());
    }


    public IEnumerator setAction()
    {
        while(true)
        {
            if(ouvrir)
            {
                if(numero == 1 && premiereOuverture)
                {
                    animateur.SetInteger("NumButton", numero);
                    print("1");
                }
                else if (numero == 2 && premiereOuverture)
                {
                    animateur.SetInteger("NumButton", numero);
                    print("2");
                }
                else if (numero == 3 && premiereOuverture)
                {
                    animateur.SetInteger("NumButton", numero);
                    print("3");
                }
                premiereOuverture = false;
                yield return new WaitForSeconds(3f);
                animateur.SetInteger("NumButton", 0);
                ouvrir = false;
            }
            
            yield return null;
        }
        

        
    }

    public void setNumero(int numero)
    {
        this.numero = numero;
        ouvrir = true;
    }
}
