using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField]
    float mag;
    [SerializeField]
    float magD;
    Transform mTransform;
    Rigidbody mRigidbody;
    Transform cTransform;

    void Start()
    {
        mTransform = GetComponent<Transform>();
        mRigidbody = GetComponent<Rigidbody>();
        cTransform = GameObject.Find("PCamara").GetComponent<Transform>();
    }

    void Update()
    {

    }

    public void HMove()
    {
        //movimiento vertical
        Vector3 dirV = new Vector3(0, 0, 1);
        float senV = Input.GetAxis("Vertical");
        Vector3 VelocidadV = senV * dirV * mag;
        mTransform.position += VelocidadV * Time.deltaTime;

        //movimiento horizontal
        Vector3 dirH = new Vector3(1, 0, 0);
        float senH = Input.GetAxis("Horizontal");
        Vector3 VelocidadH = senH * dirH * mag;
        mTransform.position += VelocidadH * Time.deltaTime;
    }
    //Pendiente: Separar cuerpo con cabeza/arma
    public void Apuntar()
    {
        //direccion del personaje dictada por el mouse
        float yCamara = cTransform.position.y;
        float yPosition = mTransform.position.y;
        float distanciaEyPYyC = Mathf.Abs(yCamara - yPosition);

        Ray Rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 ubicacionM = Rayo.GetPoint(distanciaEyPYyC);
        Vector3 puntero = new Vector3(ubicacionM.x, mTransform.position.y, ubicacionM.z);
        mTransform.LookAt(puntero);
    }

    public void Dash()
    {
        
        if (Input.GetButtonDown("Dash"))
        {
            float xD = Input.GetAxis("Horizontal");
            float zD = Input.GetAxis("Vertical");

            Vector3 dirD;
            if (zD == 0 && xD == 0)
            {
                dirD = mTransform.forward;

            }
            else
            {
                dirD = new Vector3(xD, 0, zD);
            }
            
            
            float senD = 1f;
            
            Vector3 fuerzaD = dirD * magD * senD;
            mRigidbody.AddForce(fuerzaD);
        }

    }
}
