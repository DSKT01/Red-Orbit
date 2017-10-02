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
    public float dashCD;
    bool onCDD = false;
    float tD = 0f;


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
        float x = (Mathf.Abs(2 - mTransform.position.y));
        if (x < 0.8)
        {
            x = 0;
        }
        float y = 2 / (2 + x);
        //movimiento vertical
        Vector3 dirV = new Vector3(0, 0, 1);
        float senV = Input.GetAxis("Vertical");
        Vector3 VelocidadV = senV * dirV * mag * y;
        mTransform.position += VelocidadV * Time.deltaTime;

        //movimiento horizontal
        Vector3 dirH = new Vector3(1, 0, 0);
        float senH = Input.GetAxis("Horizontal");
        Vector3 VelocidadH = senH * dirH * mag * y;
        mTransform.position += VelocidadH * Time.deltaTime;
    }
    //Pendiente: Separar cuerpo con cabeza/arma
    public void Apuntar()
    {
        //direccion del personaje dictada por el mouse

        float distanciaECYP = Vector3.Distance(cTransform.position, mTransform.position);
        Ray Rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 ubicacionM = Rayo.GetPoint(distanciaECYP);
        Vector3 puntero = new Vector3(ubicacionM.x, mTransform.position.y, ubicacionM.z);
        mTransform.LookAt(puntero);

    }

    public void Salto()
    {


        if (onCDD)
        {
            tD += Time.deltaTime;
            if (tD >= dashCD)
            {
                onCDD = false;
                tD = 0;
            }
        }
        if (!onCDD)
        {


            if (Input.GetButtonDown("Salto"))
            {

                float xD = Input.GetAxis("Horizontal");
                float zD = Input.GetAxis("Vertical");

                Vector3 dirD;
                if (zD == 0 && xD == 0)
                {
                    dirD = new Vector3(mTransform.forward.x, 1, mTransform.forward.z);
                }
                else
                {
                    dirD = new Vector3(xD, 1, zD);
                }
                float senD = 1f;
                Vector3 fuerzaD = dirD * magD * senD;
                mRigidbody.AddForce(fuerzaD);

                onCDD = true;

            }
        }



    }


}
