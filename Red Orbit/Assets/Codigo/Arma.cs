﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arma : MonoBehaviour {

    Renderer[] partesBlancas;
    Transform cTransform;
    
    public bool recargando;
    Text municion;
    
    //Piscina de objetos(Atributos).
    GameObject[] piscina;
    public GameObject[][] proyectiles;

    public int proyActual = 0,                  //Tipo de proyectil actualmente seleccionado.
        instancia = 0;                          //Instancia que se va a disparar del tipo de proyectil seleccionado.
    int[] municiones;                           // Valores de la MUNICIÓN que cada proyectil tiene.
    public int[] m;                             // A este se le restará la munición y al llegar a 0 se recuperará el valor con el arreglo anterior.
    float[] tiempos;                            // Valores del TIEMPO DE RECARGA de cada proyectil.
    public float[] t;                           // lo mismo que m pero respecto a los tiempos de recarga de cada proyectil. 

    public Proyectil[] componentesDeProyectil;      // Aquí van los componentes proyectil de las balas.
    public GameObject[] tiposDeProyectil;           // Los GameObjects a los que están vinculados los componentes.
    public GameObject[] tipoSeleccionado;           // Las instancias de cada GameObject.
    public GameObject instanciaSeleccionada;        // La instancia que se va a disparar.
    BalasCompradas comprobar;
    void Start() {
        municion = GameObject.Find("Municion").GetComponent<Text>();
        comprobar = GameObject.Find("BalasP").GetComponent<BalasCompradas>();
        comprobar.Start();
        partesBlancas = GameObject.Find("PartesBlancas").GetComponentsInChildren<Renderer>();
                
        componentesDeProyectil = GameObject.Find("BalasP").GetComponentsInChildren<Proyectil>();
        tiposDeProyectil = new GameObject[componentesDeProyectil.Length];
        proyectiles = new GameObject[componentesDeProyectil.Length][];
        municiones = new int[tiposDeProyectil.Length];
        m = new int[tiposDeProyectil.Length];
        tiempos = new float[tiposDeProyectil.Length];
        t = new float[tiposDeProyectil.Length];

        for (int i = 0; i < componentesDeProyectil.Length; i++)     //obtener los gameobjects de los componentes y ponerlos en el arreglo: tiposDeProyectil.
        {
                tiposDeProyectil[i] = componentesDeProyectil[i].gameObject;
        }

        for (int i = 0; i < tiposDeProyectil.Length; i++)
        {
            proyectiles[i] = PiscinaDeObjetos(tiposDeProyectil[i], tiposDeProyectil[i].GetComponent<Proyectil>().municion);     //Instanciar cada bala.
            municiones[i] = tiposDeProyectil[i].GetComponent<Proyectil>().municion;                                             //Tomar los valores de la munición.
            tiempos[i] = tiposDeProyectil[i].GetComponent<Proyectil>().tiempoDeRecarga;                                         //Tomar los valores de los tiempos de recarga.
            m[i] = municiones[i];                                                                                               //igualar m a municiones.
            t[i] = tiempos[i];
        }

        for (int i = 0; i < partesBlancas.Length; i++)
        {
            partesBlancas[i].material.color = tiposDeProyectil[proyActual].GetComponent<Proyectil>().color;
        }

    }

    void Update() {

        tipoSeleccionado = proyectiles[proyActual];             // Tipo de proyectil.
        instanciaSeleccionada = tipoSeleccionado[instancia];    // Cuál de los proyectiles instanciados se va a disparar.
        
    }

    public void CambiarArma()
    {
        if (proyActual < 0)
            proyActual = proyectiles.Length - 1;

        if (proyActual > proyectiles.Length - 1)
            proyActual = 0;

       for (int i = 0; i < partesBlancas.Length; i++)
        {
            
            partesBlancas[i].material.color = tiposDeProyectil[proyActual].GetComponent<Proyectil>().color;
        }

        if (!recargando)
        {
            if (Input.GetKeyDown("e"))
            {
                if (proyActual == proyectiles.Length - 1)
                    proyActual = 0;
                else
                    proyActual++;
                instancia = 0;
                t[proyActual] = tiempos[proyActual];     // Actualizar tiempo de recarga;
            }

            if (Input.GetKeyDown("q"))
            {
                if (proyActual == 0)
                    proyActual = proyectiles.Length - 1;
                else
                    proyActual--;
                instancia = 0;
                t[proyActual] = tiempos[proyActual];     // Actualizar tiempo de recarga;
            }    
        }
    }

    public void Disparar(GameObject _proyectil)
    {
        Transform tRef = GameObject.Find("Referencia").GetComponent<Transform>();
        Transform proyTrans = _proyectil.GetComponent<Transform>();
        Proyectil proyProy = _proyectil.GetComponent<Proyectil>();

        if (Input.GetButtonDown("Fire1"))
        {
            if (proyProy.comprado)
            {
                if (!recargando)
                {
                    if (proyProy.disparable)
                    {
                        if (instancia >= 0)
                            instancia++;
                        if (instancia == tipoSeleccionado.Length)
                            instancia = 0;
                       
                        proyProy.disparable = false;
                        proyProy.enPiscina = false;

                        Rigidbody cuerpoProyectil = _proyectil.GetComponent<Rigidbody>();
                        Vector3 pos = tRef.position;
                        cuerpoProyectil.velocity = new Vector3(0, 0, 0);    //eliminar el movimiento que tenía antes la bala.
                        proyTrans.position = pos;
                        cuerpoProyectil.transform.forward = tRef.forward;
                        cuerpoProyectil.AddForce(tRef.forward * proyProy.magnitudDeDisparo);
                    }
                }
            }
        }             
    }

    public bool Recargar()
    {        
        if (Input.GetButtonDown("Fire1"))
        {
            if (tiposDeProyectil[proyActual].GetComponent<Proyectil>().enPiscina)
            {
                m[proyActual]--;
            }
        }
            

        if (m[proyActual] <= 0)
        {
            recargando = true;
            t[proyActual] -= Time.deltaTime;
            m[proyActual] = 0;

            if (t[proyActual] <= 0)
            {
                m[proyActual] = municiones[proyActual];
                recargando = false;
                t[proyActual] = tiempos[proyActual];
            }
        }

        return recargando;
    }

  

    /// <summary>
    /// Crea una piscina de objetos con una cantidad específica de éstos. (Ponerlo en el Start).
    /// </summary>
    /// <param name="_obj"></param> Objeto que se quiere instanciar.
    /// <param name="_municion"></param> Cuántas instancias se quieren de este objeto.
    GameObject[] PiscinaDeObjetos(GameObject _obj, int _cantidad)
    {
        piscina = new GameObject[_cantidad];

        Proyectil proyectil = _obj.GetComponent<Proyectil>();
        Transform _objTrans = _obj.GetComponent<Transform>();

        for (int i = 0; i < piscina.Length; i++)    // Llenar los puestos del arreglo con Instancias de la Bala.
        {
            Vector3 pos = new Vector3(_objTrans.position.x, _objTrans.position.y + 1.0f * (i + 1f), _objTrans.position.z);
            piscina[i] = GameObject.Instantiate(_obj, pos, transform.rotation);
        }

        return piscina;
    }
}
