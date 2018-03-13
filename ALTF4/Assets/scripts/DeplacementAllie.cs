using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementAllie : MonoBehaviour
{
    Rigidbody corps, corps2;
    public bool estMort = false;
    public Camera cam1, cam2, cam3,cam4;
    bool actifS = false, boutons = false, action = false;
    Animator animator;
    bool actionB = false;
   public  GameObject hitboxGrimace;
    public 

    Vector3 direction;

    private void Awake()
    {
        corps = GetComponent<Rigidbody>();
        animator = this.gameObject.GetComponent<Animator>();
        corps2 = GameObject.Find("Jacob4.0").GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start()
    {
        
        cam1.enabled = false;
        cam2.enabled = false;
        cam3.enabled = true;
        cam4.enabled = false;
        
        
        //hitboxGrimace = GameObject.Find("HitboxGrimace");
        //corps.isKinematic = true;
        StartCoroutine(mort());
    }

    // Update is called once per frame
    void Update()
    {
        
        

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
        if (cam1.enabled)
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Mortel")
        {
            estMort = true;
        }
        /*if (collision.gameObject.tag == "Action" && actionB)
        {
            action = true;
        }*/

        if (collision.gameObject.tag == "Tuile")
        {
            GameObject tuileCourante = collision.gameObject;
            var a = tuileCourante.GetComponent<EnigmeTuiles>();
            if (a.estValableS)
            {

                a.setTuileSuivante();
                
            }
            else
            {
                estMort = true;
            }

        }

        

    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Action" && Input.GetKey(KeyCode.E))
        {
            action = true;
            animator.SetBool("action", action);
        }
        else if (collision.gameObject.name == "Lvl 2 button_press" && Input.GetKey(KeyCode.E))
        {

            action = true;
            animator.SetBool("action", action);

            this.gameObject.transform.position = new Vector3(-3.265f, 2.895f, -13.556f);
            this.gameObject.transform.rotation = new Quaternion(0, 90, 0, 1);
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Tuile")
        {
            GameObject tuileCourante = collision.gameObject;
            var a = tuileCourante.GetComponent<EnigmeTuiles>();
            
                
            a.setEstValableS(false);
            actifS = false;
            
            

        }
        if (collision.gameObject.tag == "Action")
        {
            action = false;
            animator.SetBool("action", action);
        }
        if (collision.gameObject.name == "Lvl 2 button_press")
        {
            action = false;
            animator.SetBool("action", action);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "aerationEntree1" && Input.GetKey(KeyCode.E))
        {
            
            action = true;
            animator.SetBool("action", action);
            
            this.gameObject.transform.position = new Vector3(-20.266f, 2.642f, -20.929f);
            this.gameObject.transform.rotation = new Quaternion(0, 90, 0, 1);
        }
        

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Aeration")
        {
            action = false;
            animator.SetBool("action", action);
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
            print(hitboxGrimace.GetComponent<HitboxGrimace>().getGrimace());
            if (hitboxGrimace.GetComponent<HitboxGrimace>().getGrimace())
            {
                transform.SetParent(GameObject.Find("EmplacementGrimace").transform);
                transform.localPosition = Vector3.zero;
            }
        }
        cam1.enabled = !cam1.enabled;
        //corps.isKinematic = !corps.isKinematic;
        print(gameObject.name + " changerCamera()");
    }

    

    public IEnumerator mort()
    {
        while (true)
        {
            if (estMort)
            {
                //corps.isKinematic = true;
                cam1.enabled = false;
                cam2.enabled = true;
                yield return new WaitForSeconds(2);
                corps2.transform.position = new Vector3(20.209f, 0.837f, -2.73f);
                corps2.transform.Rotate(new Vector3(0, 180, 0));
                this.transform.position = new Vector3(-1.656f, 0.589f, -0.55f);
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

    public bool getActifS()
    {
        return actifS;
    }

   
}