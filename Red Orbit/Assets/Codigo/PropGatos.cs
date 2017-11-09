using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropGatos : MonoBehaviour {

    public float tDetonación;               //Tiempo que le tomará explotar.
    float t;
    bool activa = false;                    // ¿La bomba está activa o no?
    Proyectil proyComp;                     // Componente PROYECTIL.
    Renderer mRender;
    Rigidbody mCuerpo,                      // Rigidbody de la bala.
        cJugador;                           // Cuerpo del jugador.
    public float magnitudExplosion;         // Fuerza de la explosión.
    public float radio,                     // Radio de la explosión.
        upforce;                            // Fuerza ejercida hacia arriba por la explosión en los objetos afectados.
    Vector3 posExp,                         // Posición de la explosión.
        p,                                  // Posición original de la bala (En la piscina).
        s;                                  // Escala       "        "       "       "      " 
    Quaternion r;                           // Rotación original de la bala (Piscina).

    PropGatos[] compañeros;

	// Use this for initialization
	void Start () {
        mCuerpo = GetComponent<Rigidbody>();
        cJugador = GameObject.Find("Jugador").GetComponent<Rigidbody>();
        proyComp = GetComponent<Proyectil>();
        mRender = GetComponent<Renderer>();
        compañeros = GameObject.FindObjectsOfType<PropGatos>();

        t = tDetonación;
        p = transform.position;
        r = transform.rotation;
        s = transform.localScale;
    }
	
	// Update is called once per frame
	void Update () {
        Detonar();
        if (proyComp.enPiscina)
        {
            mCuerpo.Sleep();
            mCuerpo.velocity = new Vector3(0, 0, 0);
            transform.localScale = s;
        }

        if (proyComp.enPiscina)
        {
            activa = false;
            mRender.material.color = new Color(1, 1, 1);
        }

        if (activa)
        {
            mRender.material.color += new Color((1 / tDetonación) * Time.deltaTime, -(1 / tDetonación) * Time.deltaTime, -(1 / tDetonación) * Time.deltaTime);
            transform.localScale += new Vector3(0.25f, 0.25f, 0.25f) * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision _x)
    {
        if (_x.gameObject.tag == "Terreno" || _x.gameObject.tag == "Enemigo")
            activa = true;
    }

    void Detonar()
    {
        if (!proyComp.enPiscina)
        { 
            if (activa)
            {
                t -= Time.deltaTime;
                if (t <= 0)
                {
                    activa = false;                                                                           // Desactivar la Bomba.
                    posExp = transform.position;
                    Collider[] colliders = Physics.OverlapSphere(posExp, radio);                                // Obtener el collider de los objetos en el radio de la explosion.

                    foreach (Collider golpeado in colliders)
                    {
                        Rigidbody c = golpeado.GetComponent<Rigidbody>();                                       // Obtener el rigidbody de cada objeto golpeado por la explosión.
                        if (c != null)                                                                          // Que no lo aplique si no hay rigidbody.
                            c.AddExplosionForce(magnitudExplosion, posExp, radio, upforce, ForceMode.Acceleration);  // Explotar esa vaina.
                    }
                    transform.position = p;                                                                     // Devolverla a la piscina.
                    transform.rotation = r;
                    t = tDetonación;                                                                            // Reiniciar el conteo de detonación.
                    proyComp.disparable = true;
                    proyComp.enPiscina = true;
                }
            }
        }
    }

    /*int Verificar()
    {
        int resultado = 0;
        foreach (PropGatos compañero in compañeros)
        {
            if (compañero.proyComp.enPiscina)
                resultado++;
        }
        Debug.Log(resultado);
        return resultado;
    }*/
}
