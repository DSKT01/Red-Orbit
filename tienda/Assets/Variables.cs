using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour {
    public int monedas;
    public int muertes;
    public int armas;
    public int aVida;
    public int dash;
    public int mMonedas;
    public bool señuelo;
    public bool boss;

    // Use this for initialization
    void Start() {
        monedas = 0;
        muertes = 0;
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
