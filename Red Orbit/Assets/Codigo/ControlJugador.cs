using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    Movimiento mMovimiento;
    SeleccionPJ seleccion;

    void Start()
    {
        mMovimiento = GetComponent<Movimiento>();
        seleccion = GameObject.Find("SeleccionDePersonaje").GetComponent<SeleccionPJ>();
    }


    void Update()
    {

        if (seleccion.seleccionPJ == true)
        {
            mMovimiento.HMove();
            //Pendiente: Separar cuerpo con cabeza/arma
            mMovimiento.Apuntar();
            mMovimiento.Salto();
        }
        
    }
}
