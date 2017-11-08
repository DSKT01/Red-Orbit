using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public bool comprado = true;
    public float daño;
    public float magnitudDeDisparo;
    public int municion;
    public bool disparable = true;
    public bool usaInclinación = false;
    public float tiempoDeRecarga;

    public bool enPiscina = true;

    Transform cTrans;
    Vector3 vectorcito;
    Renderer mRenderer;
    public Color color;
    Rigidbody mCuerpo;
    public Vector3 posicionOriginal;       
    public Quaternion rotacionOriginal;
 
    void Start()
    {
        cTrans = GameObject.Find("PCamara").GetComponent<Transform>();
        vectorcito = Vector3.Cross(cTrans.forward, cTrans.right);
        mRenderer = GetComponent<Renderer>();
        posicionOriginal = transform.position;  // Guardar las rotaciones y posiciones en que se crearon.
        rotacionOriginal = transform.rotation;

        mCuerpo = GetComponent<Rigidbody>();
        mCuerpo.Sleep();
    }
    
    void Update()
    {
        transform.LookAt(Camera.main.transform.position, cTrans.up);
    }

    void producto()
    {

    }
}
