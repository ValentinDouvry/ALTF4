using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class declenchementFleche : MonoBehaviour {

    GameObject[] fleches;
    // Use this for initialization
    void Awake () {
        fleches = new GameObject[]
        {
            GameObject.Find("fleche1"),
            GameObject.Find("fleche2"),
            GameObject.Find("fleche3"),
            GameObject.Find("fleche4"),
            GameObject.Find("fleche5"),
            GameObject.Find("fleche6"),
            GameObject.Find("fleche7"),
            GameObject.Find("fleche8"),
            GameObject.Find("fleche9"),
            GameObject.Find("fleche10"),
            GameObject.Find("fleche11"),
            GameObject.Find("fleche12"),
            GameObject.Find("fleche13"),
            GameObject.Find("fleche14"),
            GameObject.Find("fleche15"),
            GameObject.Find("fleche16"),
            GameObject.Find("fleche17"),
            GameObject.Find("fleche18"),
 
        };

        
       




    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Grimace")
        {
            for (int i = 0; i < fleches.Length; i++)
            {
                var a = fleches[i].GetComponent<PackFleches1>();
               // a.envoyerFleche(true);
            }

        }
    }
}
