using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    Movimiento mMovimiento;
   
    void Start()
    {
        mMovimiento = GetComponent<Movimiento>();
        
    }

    
    void Update()
    {      
            mMovimiento.HMove();
            //Pendiente: Separar cuerpo con cabeza/arma
            mMovimiento.Apuntar();
            mMovimiento.Salto();        
    }
}
