using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour {
    public int monedas = 0;
    public int muertes = 0;
    public int armas;
    public int aVida;
    public int dash;
    public int mMonedas;
    public bool señuelo;
    public bool boss;

    // Use this for initialization
    void Start() {

        armas = 1;
        aVida = 1;
        dash = 1;
        mMonedas = 1;
        señuelo = false;
        boss = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
