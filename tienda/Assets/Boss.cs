using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {
    Variables variables;
    public Text texto;
    int precio = 10000;

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
        if (variables.monedas > precio && variables.boss == false)
        {
            variables.boss=true;
            variables.monedas -= precio;
        }
    }
    private void OnMouseOver()
    {

        texto.rectTransform.position = Input.mousePosition;
        if (variables.boss == true)
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
