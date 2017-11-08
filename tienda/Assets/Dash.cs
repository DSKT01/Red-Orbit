using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dash : MonoBehaviour {

    Variables variables;
    public Text texto;
    int precio = 300;

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
        if (variables.monedas > precio && variables.dash == 2)
        {
            variables.dash++;
            variables.monedas -= precio;
        }
        if (variables.monedas > precio && variables.dash == 1)
        {
            variables.dash++;
            variables.monedas -= precio;
            precio = 600;
        }

    }
    private void OnMouseOver()
    {

        texto.rectTransform.position = Input.mousePosition;
        if (variables.dash == 3)
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
