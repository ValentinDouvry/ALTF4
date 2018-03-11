using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviour
{
    public GameObject menuPrincipal;

    public void ButtonQuitter()
    {
        Debug.Log("Le jeu va se fermer!");
        Application.Quit();
    }

    

    public void ButtonJouer()
    {
        SceneManager.LoadScene(1);
        print("Jouer");
    }

    

    public void recommencer()
    {
        //TODO
    }
}
