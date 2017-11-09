using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalasCompradas : MonoBehaviour {
    Proyectil[] comprados;
    Variables variables;
    // Use this for initialization
   public void Start() {
        comprados = GetComponentsInChildren<Proyectil>();
        variables = GameObject.Find("Variables").GetComponent<Variables>();
        for (int i = 0; i < comprados.Length; i++)
        {
            if (i < variables.armas)
            {
                comprados[i].comprado = true;
                
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(variables.armas);
	}
}
