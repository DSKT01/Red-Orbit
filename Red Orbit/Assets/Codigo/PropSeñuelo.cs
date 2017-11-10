using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSeñuelo : MonoBehaviour
{
    Rigidbody mCuerpo;
    GameObject señuelo;
    Proyectil proyComp;
    PropSeñuelo[] compañeros;
    public float tDespliegue;
    public float dMax;
    bool activo;
    float dm;
    float d;
    public int c = 0;
    Vector3 p;
    Quaternion r;
    public float tS;
    // Use this for initialization
    void Start()
    {
        mCuerpo = GetComponent<Rigidbody>();
        proyComp = GetComponent<Proyectil>();
        señuelo = GameObject.Find("Maniqui");
        compañeros = GameObject.FindObjectsOfType<PropSeñuelo>();

        p = transform.position;
        r = transform.rotation;

        proyComp.municion = 1;      // La munición de este proyectil siempre está limitada a 1.
        dm = 0;
        d = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (c == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                activo = true;
                c = 1;
            }
        }

        if (activo)
        {
            dm += Time.deltaTime;
            if (dm >= dMax)
                Reaparecer();

            d += Time.deltaTime;

            if (d >= tDespliegue)
            {
                Desplegar();
            }
        }

        if (Verificar() == 1)
            proyComp.disparable = true;
    }

    void Desplegar()
    {
        GameObject senuelo = Instantiate(señuelo, transform.position, Quaternion.identity);
        Señuelo posible = senuelo.GetComponent<Señuelo>();
        posible.activo = true;
        posible.duracion = tS;
        posible.posible = this.gameObject.GetComponent<PropSeñuelo>();
        Reaparecer();
        print(transform.position);
    }

    void Reaparecer()
    {
        transform.position = p;
        transform.rotation = r;
        if (Verificar() == 0)
            proyComp.disparable = true;
        proyComp.enPiscina = true;
        activo = false;
        d = 0;
        dm = 0;
    }

    int Verificar()
    {
        int resultado = 0;
        foreach (PropSeñuelo compañero in compañeros)
        {
            if (compañero.proyComp.enPiscina)
                resultado++;
        }
        Debug.Log(resultado);
        return resultado;
    }
}
