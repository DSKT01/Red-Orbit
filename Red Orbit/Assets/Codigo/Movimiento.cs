using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {
    [SerializeField]
    float mag;
    [SerializeField]
    float magR;
    Transform mTransform;

	// Use this for initialization
	void Start () {
        mTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HMove()
    {
        Vector3 dirV = transform.forward;
        float senV = Input.GetAxis("Vertical");
        Vector3 VelocidadV = senV * dirV * mag;
        mTransform.position += VelocidadV * Time.deltaTime;

        Vector3 dirH = transform.up;
        float senH = Input.GetAxis("Horizontal");
        Vector3 VelocidadH = senH * dirH;
        mTransform.position += VelocidadH * Time.deltaTime;



    }
}
