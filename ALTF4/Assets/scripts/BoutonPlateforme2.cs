using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonPlateforme2 : MonoBehaviour {

    GameObject plateforme1, plateforme2, plateforme3;

    private void Awake()
    {
        plateforme1 = GameObject.Find("Plateforme1");
        plateforme2 = GameObject.Find("Plateforme2");
        plateforme3 = GameObject.Find("Plateforme3");
    }

    // Use this for initialization
    void Start() {}

    // Update is called once per frame
    void Update() {}

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            plateforme1.GetComponent<Plateforme1>().setAction(true, 2);
            plateforme2.GetComponent<Plateforme2>().setAction(true, 2);
            plateforme3.GetComponent<Plateforme3>().setAction(true, 2);
        }
    }
}