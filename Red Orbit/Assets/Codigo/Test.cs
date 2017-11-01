using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
    Transform cTrans;
    Transform jTrans;
	// Use this for initialization
	void Start () {
        cTrans = GameObject.Find("PCamara").GetComponent<Transform>();
        jTrans = GameObject.Find("Jugador").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        float distancia = Vector3.Distance(cTrans.position, jTrans.position) ;
        Ray Rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 ubicacionM = new Vector3  (Rayo.GetPoint(distancia).x, jTrans.position.y, Rayo.GetPoint(distancia).z) ;
        transform.position = ubicacionM;
        
    }
}
