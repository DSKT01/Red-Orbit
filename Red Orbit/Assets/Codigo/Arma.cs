using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour {

    /*  (Sé que no es necesario pero me gusta comentar cosas)
     *  
     *  NECESARIO PARA IMPLEMENTAR EL CODIGO:
     *  1. El arma como tal a la que se le aplicará el componente (duuuh)
     *  2. Referencia de la posición.
     *  3. Objeto proyectil.
     *  4. Debe existir una instancia del objeto proyectil escondida en algún lugar.  <---------- ¡IMPORTANTE!
     */

    /*  PENDIENTE:
     *  1. Agregar daño al proyectil.
     *  2. Hacer que la luz parpadee mientras recarga munición.
     *  
     */
    [SerializeField]
    float tRecarga;
    float t;            // Tiempo de recarga.
    [SerializeField]
    float intensidadLuz;
    [SerializeField]
    int municion;
    int m;              // Cantidad de balas que se pueden disparar.
    [SerializeField]
    bool recargando;
    Light mLuz;
    Transform cTransform;
    float rotacion;


    void Start() {
        recargando = false;
        m = municion;   //almacena el valor de la munición para que al recargar esta vuelva a llenarse.
        t = tRecarga;   //almacena el tiempo que va a demorar la recarga.

        mLuz = GetComponent<Light>();
        mLuz.intensity = intensidadLuz;

        rotacion = transform.eulerAngles.x;

        // apuntar:
        cTransform = GameObject.Find("PCamara").GetComponent<Transform>();
    }

    void Update() {
        Disparar();
        Apuntar();
        
    }

    /// <summary>
    /// Incluye recarga
    /// </summary>
    void Disparar()
    {
        GameObject proyectil, pClon;
        Transform trRef = transform.Find("Referencia").GetComponent<Transform>();
        Vector3 pos = trRef.position;   // Obtener posición de la referencia.

        if (Input.GetButtonDown("Fire1"))   // instanciar el proyectil.
        {
            if (recargando == false)    // Si no está recargando.
            {
                proyectil = GameObject.Find("Proyectil");
                pClon = Instantiate(proyectil, pos, Quaternion.identity);
                Proyectil p = pClon.GetComponent<Proyectil>();    //  <---- Componente proyectil del clon.
                p.disparado = true;

                mLuz.intensity -= intensidadLuz / m;

                municion--;
            }
        }

        #region Recargar
        if (tRecarga < t)
        {
           
            recargando = true;
            tRecarga -= Time.deltaTime;

            if (tRecarga < 0)
            {
                recargando = false;
                municion = m;   // La munición vuelve a llenarse.
                tRecarga = t;   // Se reinicia el cooldown.
                mLuz.intensity = intensidadLuz;     // Se reinicia la intensidad de la luz.
            }
        }

        if (municion == 0)  // Recargar alahu akhbar las balas. (leer rápido)
            tRecarga -= 0.001f;

        if (Input.GetButtonUp("Fire2"))   // Recargar manualmente (POR AHORA CON EL CLIC DERECHO)
        {
            if (municion < m)             // No puede recargar si tiene toda la munición.
                tRecarga -= 1.0f;           // si recarga antes de que las balas se le acaben tardará menos tiempo en recargar.
        }
        #endregion
    }

    void Apuntar()
    {
        float distanciaECYP = Vector3.Distance(cTransform.position, transform.position);
        Ray Rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 ubicacionM = Rayo.GetPoint(distanciaECYP);
        Vector3 puntero = new Vector3(ubicacionM.x, transform.position.y, ubicacionM.z);
        transform.LookAt(puntero);

        // Rotación en x.-------------------------------------------------------------------

        float distanciaJyP = Vector3.Distance(transform.position, puntero);
        float a = -distanciaJyP/4;
        Vector3 giro = new Vector3(a, 0, 0);

        transform.eulerAngles += giro;
    }
}
