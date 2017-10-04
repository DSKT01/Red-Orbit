using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlJugador : MonoBehaviour
{
    public float life = 10f;
    Movimiento mMovimiento;
    Image barraVida;
    Arma arma;
    GameObject muerte;
    void Start()
    {
        mMovimiento = GetComponent<Movimiento>();
        barraVida = GameObject.Find("Barra").GetComponent<Image>();
        arma = GetComponentInChildren<Arma>();
        barraVida.fillAmount = 1;
        muerte = GameObject.Find("Muerte");
    }


    void Update()
    {

        
            mMovimiento.HMove();
            //Pendiente: Separar cuerpo con cabeza/arma
            mMovimiento.Apuntar();
            mMovimiento.Salto();
            arma.Disparar();
            arma.Apuntar();
       if (life <= 0)
        {
            Time.timeScale = 0;
            muerte.SetActive(true);
            
        }
        
        
    }
    public void Damage(float x)
    {
        life = life - x;
        barraVida.fillAmount = life / 10f;
    }
}
