using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {
    [SerializeField]
    float mag;
    [SerializeField]
    float magR;
    Transform mTransform;
    Camera Camara = Camera.main;
    Rigidbody mRigidbody;

	// Use this for initialization
	void Start () {
        mTransform = GetComponent<Transform>();
        mRigidbody = GetComponent<Rigidbody>();
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

        Vector3 dirH = transform.right;
        float senH = Input.GetAxis("Horizontal");
        Vector3 VelocidadH = senH * dirH * mag;
        mTransform.position += VelocidadH * Time.deltaTime;

        RaycastHit MPA;
        int Piso = LayerMask.GetMask("Terrain");
        Ray Rayo = Camara.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(Rayo, out MPA,100,Piso))
        {
            Vector3 MP = MPA.point - mTransform.position;
            MP.y = 0f;
            Quaternion Giro = Quaternion.LookRotation(MP);
            mRigidbody.MoveRotation(Giro);
        }

        
       

    }
}
