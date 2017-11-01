using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direccion : MonoBehaviour
{
    Transform mTrasn;
    Vector3 lastPosition;
    Vector3 dir;
    // Use this for initialization
    void Start()
    {
        mTrasn = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirH = Input.GetAxis("Horizontal");
        float dirV = Input.GetAxis("Vertical");
        dir = new Vector3(dirH, 0, dirV);
        if ((dirH != 0) || (dirV != 0))
        {
            Almacen();
        }
        mTrasn.localPosition = lastPosition;

    }

    void Almacen()
    {
        lastPosition = dir;
    }
}
