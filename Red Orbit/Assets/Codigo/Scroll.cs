using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll : MonoBehaviour {

    public Scrollbar scroll;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        scroll.value -= Input.mouseScrollDelta.y/20;
        transform.position = new Vector3(transform.position.x, 3.4f + (scroll.value*17.5f), transform.position.z);
            
            
	}
}
