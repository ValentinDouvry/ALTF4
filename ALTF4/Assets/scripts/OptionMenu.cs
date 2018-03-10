using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviour
{
    public GameObject menuPrincipal,
    menuCommandes,
    menus,
    menuFinDePartie;

    public void quitter()
    {
        Debug.Log("Le jeu va se fermer!");
        Application.Quit();
    }

    public void commandes()
    {
        menuCommandes.SetActive(true);
        menuPrincipal.SetActive(false);

    }

    public void jouer()
    {
        SceneManager.LoadScene(1);
    }

    public void retour()
    {
        menuPrincipal.SetActive(true);
        menuCommandes.SetActive(false);

    }

    public void recommencer()
    {
        //TODO
    }
}
