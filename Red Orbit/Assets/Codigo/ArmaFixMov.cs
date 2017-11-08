using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaFixMov : MonoBehaviour {
    [SerializeField]
    Transform target;
    Vector3 fixVector;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        fixVector = new Vector3(target.forward.x, -target.forward.y, target.forward.z);
        transform.forward = fixVector;

	}
    
}
