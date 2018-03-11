using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSpikes : MonoBehaviour {


    GameObject spikes;
    Animator animator;
    bool spikeSortir = false;
    // Use this for initialization
    void Awake () {
        spikes = GameObject.Find("anim_spikeSpike");
        animator = spikes.GetComponent<Animator>();
        //animator.SetBool("spikeSortir", false);

    }
	
	// Update is called once per frame
	void Update () {
        animator.SetBool("spikeSortir", spikeSortir);
        

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Jacob")
        {
            spikeSortir = true;
            animator.SetBool("spikeSortir", spikeSortir);

        }
        
    }



    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Jacob")
        {
            spikeSortir = false;
            animator.SetBool("spikeSortir", spikeSortir);

        }

    }
}
