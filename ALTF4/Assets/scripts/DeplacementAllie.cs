using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementAllie : MonoBehaviour
{

    Rigidbody corps;
    public bool estMort = false;
    Camera cam1, cam2;
    bool actifP = true, actifS = false, boutons = false, action = false;
    Animator animator;

    private void Awake()
    {
        corps = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start()
    {
        cam1 = Camera.main;
        cam2 = GameObject.Find("CameraMort").GetComponent<Camera>();
        cam1.enabled = true;
        cam2.enabled = false;
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {}

    public void FixedUpdate()
    {
        Vector3 direction = new Vector3();

        if (Input.GetKey(KeyCode.UpArrow))
            direction.z += 1f;
        if (Input.GetKey(KeyCode.DownArrow))
            direction.z -= 1f;
        if (Input.GetKey(KeyCode.LeftArrow))
            direction.x -= 1f;
        if (Input.GetKey(KeyCode.RightArrow))
            direction.x += 1f;
        if (Input.GetKey(KeyCode.Space))
            direction.y += 1f;
        if (Input.GetKey(KeyCode.LeftShift))
            direction.y -= 1f;

        corps.velocity = (direction * Time.deltaTime * 100);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Mortel")
        {
            mort();
        }
        if (collision.gameObject.tag == "Action" && Input.GetKey(KeyCode.E))
        {
            action = true;
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Tuile")
        {
            GameObject tuileCourante = collision.gameObject;
            var a = tuileCourante.GetComponent<EnigmeTuiles>();
            /*if (a.estValableP)
            {
                a.setEstValableP(false);
                actifP = false;
            } else
            {
                cam1.enabled = true;
                cam2.enabled = false;
            }*/
            if (a.estValableS)
            {
                a.setEstValableS(false);
                actifS = false;
            }
            else
            {
                cam1.enabled = true;
                cam2.enabled = false;
            }

        }
    }

    public IEnumerator mort()
    {
        while (true)
        {
            if (estMort)
            {
                corps.isKinematic = true;
                cam1.enabled = false;
                cam2.enabled = true;
                yield return new WaitForSeconds(2);
                transform.position = new Vector3(0, 0, 0);
                corps.isKinematic = false;
                cam1.enabled = true;
                cam2.enabled = false;
                estMort = false;
            }
            yield return null;
        }
    }

    public IEnumerator actionAnim()
    {
        while (true)
        {
            if (action)
            {
                yield return new WaitForSeconds(2);
                action = false;
            }
            yield return null;
        }
    }
}