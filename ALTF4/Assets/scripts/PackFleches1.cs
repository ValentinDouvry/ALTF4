using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackFleches1 : MonoBehaviour {

    Rigidbody body;
    Vector3 position;
    bool reset = false;

	// Use this for initialization
	void Awake () {
        body = this.gameObject.GetComponent<Rigidbody>();
        position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }
    
	
	// Update is called once per frame
	void Update () {
        envoyerFleche();
    }
    private void Start()
    {
        StartCoroutine(envoyerFleche());
    }

    public IEnumerator envoyerFleche()
    {
        print("test");
        body.AddForce(transform.forward * 400);
        yield return new WaitForSeconds(2);
        this.transform.position = position;
        this.transform.Rotate(new Vector3(0, 0, 0));

    }      
}
