using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultMon : MonoBehaviour {

    Variables variables;
    public Text texto;
    int precio = 450;

    // Use this for initialization
    void Start()
    {
        variables = GameObject.Find("Variables").GetComponent<Variables>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        if (variables.monedas > precio && variables.mMonedas == 2)
        {
            variables.mMonedas++;
            variables.monedas -= precio;
        }
        if (variables.monedas > precio && variables.mMonedas == 1)
        {
            variables.mMonedas++;
            variables.monedas -= precio;
            precio = 900;
        }

    }
    private void OnMouseOver()
    {

        texto.rectTransform.position = Input.mousePosition;
        if (variables.mMonedas == 3)
        {
            texto.text = "Unlocked";
        }
        else
            texto.text = precio.ToString();
    }

    private void OnMouseExit()
    {
        texto.text = "";
    }
}
