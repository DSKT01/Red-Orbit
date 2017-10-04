using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    public float life = 10f;
    Movimiento mMovimiento;
    SeleccionPJ seleccion;
    Arma arma;
    void Start()
    {
        mMovimiento = GetComponent<Movimiento>();
        seleccion = GameObject.Find("SeleccionDePersonaje").GetComponent<SeleccionPJ>();
        arma = GetComponentInChildren<Arma>();
    }


    void Update()
    {

        if (seleccion.seleccionPJ == true)
        {
            mMovimiento.HMove();
            //Pendiente: Separar cuerpo con cabeza/arma
            mMovimiento.Apuntar();
            mMovimiento.Salto();
            arma.Disparar();
            arma.Apuntar();
        }
        
    }
}
