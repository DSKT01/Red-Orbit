using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionCirculo : MonoBehaviour {
    float a, t;
    Vector3 v;
	// Use this for initialization
	void Start () {
        t = Random.Range(1, 5);
	}
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        a = (Mathf.Sin(t*5) + 2) * Time.deltaTime * 50;
        v = new Vector3(0, a, 0);
        transform.eulerAngles += v;
	}
}
