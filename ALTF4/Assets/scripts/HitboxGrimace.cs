using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxGrimace : MonoBehaviour {

    bool grimace = false;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Grimace")
        {
            print("Coulizion");
            grimace = true;
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "Grimace")
        {
            grimace = false;
        }
    }

    public bool getGrimace()
    {
        return grimace;
    }
}