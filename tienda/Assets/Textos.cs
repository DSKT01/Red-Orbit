using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Textos : MonoBehaviour {
    Variables variables;
    public Text moneditas;
    public Text muertesitas;
	// Use this for initialization
	void Start () {
        variables = GameObject.Find("Variables").GetComponent<Variables>();
	}
	
	// Update is called once per frame
	void Update () {
        moneditas.text = variables.monedas.ToString();
        muertesitas.text = variables.muertes.ToString();
	}
}
