using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    GameObject muerte;


    // Use this for initialization
    void Start()
    {
        muerte = GameObject.Find("Muerte");
        if (muerte != null)
        {
            muerte.SetActive(false);
        }
        
        
    }


    // Update is called once per frame
    void Update()
    {

    }
    public void Jugar()
    {
        SceneManager.LoadScene("Game");
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");

    }
    public void Tienda()
    {
        SceneManager.LoadScene("Tienda");
    }

    public void Instrucciones()
    {
        SceneManager.LoadScene("Istrucciones");
    }
    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

}
