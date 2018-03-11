using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionAttache : MonoBehaviour {

    private bool isAutoControlled;
    private bool isAttached;

    public GameObject EmplacementGrimace;

    public void AttachToShoulder()
    {
        // Démarre un genre de Thread qui roule jusqu'à ce que Grimage soit proche du point et l'attache
        StartCoroutine(MoveToAttache());
    }

    public void DetacheGrimace()
    {
        isAttached = false;
        transform.SetParent(null);
    }

    private void Update()
    {
        if (isAutoControlled)
        {
            Debug.Log("Grimace est en train de bouger vers le point d'attache");
        }

        if (isAttached)
        {
            Debug.Log("Grimace est attaché au joueur");
        }
    }

    IEnumerator MoveToAttache()
    {
        isAutoControlled = true;

        //Tant que grimage est à plus de 0.2 mètres du point d'attache
        while (Vector3.Distance(transform.position, EmplacementGrimace.transform.position) > 0.2f)
        {
            // TODO Bouge vers le point d'attache


            // Passe un frame
            yield return new WaitForEndOfFrame();
        }

        // Rendu ici on sait qu'on est à moins de 0.2 mètres du point d'attache, alors on le clip dessus
        transform.SetParent(EmplacementGrimace.transform);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        isAttached = true;
        isAutoControlled = false;
    }
}
