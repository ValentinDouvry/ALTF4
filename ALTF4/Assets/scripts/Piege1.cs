using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piege1 : MonoBehaviour {

    Rigidbody corps;
    bool action = false;

    private void Awake ()
    {
        corps = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(lancerPiege());
    }
	
	// Update is called once per frame
	void Update () {}

    public IEnumerator lancerPiege()
    {
        while (true)
        {
            if (action)
            {
                corps.velocity = (new Vector3(0, 0, 200) * Time.deltaTime * 3);
                yield return new WaitForSeconds(2);
                corps.velocity = Vector3.zero;
                corps.angularVelocity = Vector3.zero;
                action = false;
            }
            yield return null;
        }
    }

    public void setAction(bool valeur)
    {
        action = valeur;
    }
}
