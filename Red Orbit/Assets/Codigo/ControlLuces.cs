using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLuces : MonoBehaviour
{
    Transform mTransform;
    GameObject jugador;
    Transform jTransform;
    Movimiento jMovimiento;
    bool activado = false;
    Light mLuz;
    float t = 0;
    float CD;
    Rect Pantalla;

    // Use this for initialization
    void Start()
    {
        mTransform = GetComponent<Transform>();
        jugador = GameObject.Find("Jugador");
        jTransform = jugador.GetComponent<Transform>();
        mLuz = GetComponent<Light>();
        jMovimiento = jugador.GetComponent<Movimiento>();
        CD = jMovimiento.dashCD;

    }

    // Update is called once per frame
    void Update()
    {
        Pantalla = new Rect(0, 0, Screen.width, Screen.height);
        mTransform.LookAt(jTransform);

        if (Input.GetButtonDown("Salto") && activado == false)
        {
            activado = true;
        }

        if (activado)
        {
            mLuz.intensity = (Mathf.Sin(Mathf.Pow(t * 2f, 2)) + 1) / 2;
            mLuz.color = new Color(1, (220 / 255), (160 / 255), 1);
            t += Time.deltaTime;
            if (t >= CD)
            {
                activado = false;
                t = 0;
            }
        }
        else
        {
            mLuz.color = new Color(1, 1, 1, 1);
            mLuz.intensity = 1;
        }


    }

}
