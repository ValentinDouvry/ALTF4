using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSpikes : MonoBehaviour {


    GameObject spikes;
    Animator animator;
    // Use this for initialization
    void Awake () {
        spikes = GameObject.FindGameObjectWithTag("anim_spikeSpike");
        animator = spikes.GetComponent<Animator>();
        animator.SetBool("spikeSortir", false);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Jacob")
        {
            
            animator.SetBool("spikeSortir", true);

        }
        animator.SetBool("spikeSortir", false);
    }
}
