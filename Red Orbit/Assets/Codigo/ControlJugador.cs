using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlJugador : MonoBehaviour
{
    public float life = 10f;
    Movimiento mMovimiento;
    Image barraVidaUno;
    Image barraVidaDos;
    Arma arma;
    GameObject muerte;
    void Start()
    {
        transform.forward = new Vector3(1, 0, 0);
        mMovimiento = GetComponent<Movimiento>();
        barraVidaUno = GameObject.Find("BarraR").GetComponent<Image>();
        barraVidaDos = GameObject.Find("BarraL").GetComponent<Image>();
        arma = GetComponentInChildren<Arma>();
        barraVidaUno.fillAmount = 1;
        barraVidaDos.fillAmount = 1;
        muerte = GameObject.Find("Muerte");

    }


    void Update()
    {


        mMovimiento.HMove();
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
        barraVidaUno.fillAmount = life / 10f;
        barraVidaDos.fillAmount = life / 10f;
    }
}
