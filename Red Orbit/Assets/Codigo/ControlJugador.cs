using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    Movimiento mMovimiento;
    Rect Pantalla;
    void Start()
    {
        mMovimiento = GetComponent<Movimiento>();
        Pantalla = new Rect(0, 0, Screen.width, Screen.height);
    }

    
    void Update()
    {
        
        if (Pantalla.Contains(Input.mousePosition))
        {
            mMovimiento.HMove();
            //Pendiente: Separar cuerpo con cabeza/arma
            mMovimiento.Apuntar();
            mMovimiento.Salto();
        }

    }
}
