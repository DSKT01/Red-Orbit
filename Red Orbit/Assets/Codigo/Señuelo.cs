using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Señuelo : MonoBehaviour {

    public float duracion;
    float d;
    Proyectil proyComp;
    public PropSeñuelo posible;
    public bool activo = false;
	// Use this for initialization
	void Start () {
        d = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (activo)
        {
            d += Time.deltaTime;
            if (d >= duracion)
            {
                posible.c = 0;
                Destroy(this.gameObject);
            }
        }

	}
}
