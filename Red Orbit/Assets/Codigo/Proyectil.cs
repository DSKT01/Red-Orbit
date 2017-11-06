using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float daño;
    public float magnitudDeDisparo;
    public int municion;
    public bool disparable = true;
    public bool usaInclinación = false;
    public float tiempoDeRecarga;
    public float duracionEnElCampo;
    float cont;
    public bool enPiscina = true;

    Renderer mRenderer;
    public Color color;
    Rigidbody mCuerpo;
    public Vector3 posicionOriginal;       
    public Quaternion rotacionOriginal;
 
    void Start()
    {
        mRenderer = GetComponent<Renderer>();
        posicionOriginal = transform.position;  // Guardar las rotaciones y posiciones en que se crearon.
        rotacionOriginal = transform.rotation;

        mCuerpo = GetComponent<Rigidbody>();
        mCuerpo.Sleep();
        cont = duracionEnElCampo;
        mRenderer.material.color = color;
    }
    
    void Update()
    {
        reaparecer();
        if (enPiscina)
            transform.position = posicionOriginal;
    }

    public void reaparecer()
    {
        if (!disparable)
        {
            duracionEnElCampo -= Time.deltaTime;
            if (duracionEnElCampo <= 0)
            {
                disparable = true;
                transform.position = posicionOriginal;
                transform.rotation = rotacionOriginal;
                mCuerpo.velocity = new Vector3(0, 0, 0);
                duracionEnElCampo = cont;
                mCuerpo.Sleep();    // Dormir para evitar el caos en la piscina de objetos.
                enPiscina = true;
            }
        }
    }

    void OnCollisionEnter(Collision _x)
    {

    }
}
