using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour {
    Movimiento mMovimiento;
	// Use this for initialization
	void Start () {
        mMovimiento = GetComponent<Movimiento>();
	}
	
	// Update is called once per frame
	void Update () {
        mMovimiento.HMove();
	}
}
