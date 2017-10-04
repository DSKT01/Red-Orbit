using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlJugador : MonoBehaviour
{
    public float life = 10f;
    Movimiento mMovimiento;
    Scrollbar barraVida;
    Arma arma;
    void Start()
    {
        mMovimiento = GetComponent<Movimiento>();
        barraVida = GameObject.Find("Barra").GetComponent<Scrollbar>();
        arma = GetComponentInChildren<Arma>();
    }


    void Update()
    {

        
            mMovimiento.HMove();
            //Pendiente: Separar cuerpo con cabeza/arma
            mMovimiento.Apuntar();
            mMovimiento.Salto();
            arma.Disparar();
            arma.Apuntar();
        
        
    }
    public void Damage(float x)
    {
        life = life - x;
        barraVida.size = life / 10f;
    }
}
