using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plateforme3 : MonoBehaviour {

    Rigidbody corps;
    public int bouton;
    bool action = false;

    private void Awake()
    {
        corps = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(bougerPlateforme());
    }

    // Update is called once per frame
    void Update() {}

    public IEnumerator bougerPlateforme()
    {
        while (true)
        {
            if (action)
            {
                if (bouton == 1)
                {
                    corps.velocity = (new Vector3(0, -100, 0) * Time.deltaTime * 3);
                }
                else if (bouton == 2)
                {
                    corps.velocity = (new Vector3(0, -100, 0) * Time.deltaTime * 3);
                }
                else
                {
                    corps.velocity = (new Vector3(0, +100, 0) * Time.deltaTime * 3);
                }
                yield return new WaitForSeconds(1);
                corps.velocity = Vector3.zero;
                corps.angularVelocity = Vector3.zero;
                action = false;
            }
            yield return null;
        }
    }

    public void setAction(bool valeur, int num)
    {
        bouton = num;
        action = valeur;
    }
}

