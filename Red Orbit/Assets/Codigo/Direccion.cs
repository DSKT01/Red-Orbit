using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direccion : MonoBehaviour
{
    Transform mTrasn;
    Vector3 lastPosition;
    Vector3 dir;
    Transform jTrans;
    // Use this for initialization
    void Start()
    {
        mTrasn = GetComponent<Transform>();
        jTrans = GameObject.Find("Jugador").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.timeScale == 1)
        {
           
            float dirH = Input.GetAxis("Horizontal");
            float dirV = Input.GetAxis("Vertical");
            
            dirH = Redondear(dirH);
           
            dirV = Redondear(dirV);
            
            dir = new Vector3(dirH, 0, dirV);
            if ((dirH != 0) || (dirV != 0))
            {
                Almacen();
            }
            mTrasn.position = lastPosition + jTrans.position;
        }


    }

    void Almacen()
    {
       
            lastPosition = dir;
        
        
    }
    int Redondear(float x)
    {
        if (x > 0)
        {
            x = 1;
        }
        if (x < 0)
        {
            x = -1;
        }
        
        return (int)x;
    }
}
