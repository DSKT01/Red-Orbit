using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direccion : MonoBehaviour
{
    Transform mTrasn;

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
        Vector3 dir = new Vector3(dirH, 0, dirV);
        mTrasn.localPosition = dir;


    }
}
