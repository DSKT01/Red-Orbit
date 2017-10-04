using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour {
    GameObject menu;

    
	// Use this for initialization
	void Start () {
        menu = GameObject.Find("Menu");
        Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Jugar()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Salir()
    {
        Application.Quit();
    }
}
