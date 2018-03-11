using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementAllie : MonoBehaviour
{
    Rigidbody corps, corps2;
    public bool estMort = false;
    Camera cam1, cam2, cam3;
    bool actifP = true, actifS = false, boutons = false, action = false;
    Animator animator;
    bool actionB = false;
    GameObject hitboxGrimace;

    Vector3 direction;

    private void Awake()
    {
        corps = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start()
    {
        cam1 = GameObject.Find("CameraGrimace").GetComponent<Camera>();
        cam2 = GameObject.Find("CameraMort").GetComponent<Camera>();
        cam3 = GameObject.Find("CameraJacob").GetComponent<Camera>();
        cam1.enabled = false;
        cam2.enabled = false;
        cam3.enabled = true;
        animator = this.gameObject.GetComponent<Animator>();
        corps2 = GameObject.Find("Jacob3.0").GetComponent<Rigidbody>();
        hitboxGrimace = GameObject.Find("HitboxGrimace");
        corps.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        direction = Vector3.zero;
        if (Input.GetKey(KeyCode.E))
        {
            actionB = true;
        }
        else
        {
            actionB = false;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            changerCamera();
        }
        /*
        if (Input.GetKey(KeyCode.UpArrow))
            direction.z += 1f;
        if (Input.GetKey(KeyCode.DownArrow))
            direction.z -= 1f;
        if (Input.GetKey(KeyCode.LeftArrow))
            direction.x -= 1f;
        if (Input.GetKey(KeyCode.RightArrow))
            direction.x += 1f;
        */
        if (!corps.isKinematic)
        {
            if (Input.GetKey(KeyCode.Space))
                direction.y += 1f;
            if (Input.GetKey(KeyCode.LeftShift))
                direction.y -= 1f;
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);
        }
    }

    public void FixedUpdate()
    {
        corps.velocity = (direction * Time.deltaTime * 100);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Mortel")
        {
            mort();
        }
        if (collision.gameObject.tag == "Action" && actionB)
        {
            action = true;
        }
    }


    private void changerCamera()
    {
        if (transform.parent)
        {
            transform.SetParent(null);
        }
        else
        {
            if (hitboxGrimace.GetComponent<HitboxGrimace>().getGrimace())
            {
                transform.SetParent(GameObject.Find("EmplacementGrimace").transform);
                transform.localPosition = Vector3.zero;
            }
        }
        cam1.enabled = !cam1.enabled;
        corps.isKinematic = !corps.isKinematic;
        print(gameObject.name + " changerCamera()");
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