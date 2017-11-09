using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    GameObject menu;
    GameObject interfaz;
    GameObject muerte;
    ControlJugador cj;


    // Use this for initialization
    void Start()
    {
        menu = GameObject.Find("Menu");
        Time.timeScale = 0;
        interfaz = GameObject.Find("Interfaz");
        muerte = GameObject.Find("Muerte");
        interfaz.SetActive(false);
        muerte.SetActive(false);
        cj = GameObject.Find("Jugador").GetComponent<ControlJugador>();

    }


    // Update is called once per frame
    void Update()
    {

    }
    public void Jugar()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
        interfaz.SetActive(true);
        cj.life = 10;

    }
    public void Salir()
    {
        Application.Quit();
    }
    public void Menu()
    {
        SceneManager.LoadScene("Game");

    }
    public void Tienda()
    {
        SceneManager.LoadScene("Tienda");
    }

}
