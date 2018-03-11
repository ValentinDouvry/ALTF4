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

    }

    public IEnumerator envoyerFleche()
    {
        print("test");
        body.AddForce(new Vector3(0, 100, 0) * Time.deltaTime);
        yield return new WaitForSeconds(2);
        body.transform.position = position;

    }      
}
