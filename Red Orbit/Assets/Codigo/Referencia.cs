using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Referencia : MonoBehaviour {
    [SerializeField]
    Transform refRef, cursor;
    Transform hTrans;
	// Use this for initialization
	void Start () {
        hTrans = GameObject.Find("Referencia").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = refRef.position;
        hTrans.LookAt(new Vector3 (cursor.position.x, transform.position.y, cursor.position.z));
	}
   
}
