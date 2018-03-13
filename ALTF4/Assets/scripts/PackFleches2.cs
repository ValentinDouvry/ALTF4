using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackFleches2 : MonoBehaviour
{

    Rigidbody body;
    Vector3 position;

    // Use this for initialization
    void Awake()
    {
        body = this.gameObject.GetComponent<Rigidbody>();
        position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //envoyerFleche();


    }

    public void envoyerFleche()
    {


        body.AddForce(transform.forward * 100f);

    }


    private void reset(int num)
    {

        body.transform.position = position;


    }
}
