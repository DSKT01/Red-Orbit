using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultMon : MonoBehaviour {

    Variables variables;
    public Text texto;
    int precio = 450;
    public Sprite spr1;
    public Sprite spr2;
    SpriteRenderer sprite;

    // Use this for initialization
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        variables = GameObject.Find("Variables").GetComponent<Variables>();
        if (variables.mMonedas == 2)
            sprite.sprite = spr1;
        if (variables.mMonedas == 3)
            sprite.sprite = spr2;
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
            sprite.sprite = spr2;
        }
        if (variables.monedas > precio && variables.mMonedas == 1)
        {
            variables.mMonedas++;
            variables.monedas -= precio;
            sprite.sprite = spr1;
            precio = 900;
        }

    }
    private void OnMouseOver()
    {

        texto.rectTransform.position = Input.mousePosition;
        if (variables.mMonedas == 3)
        {
            float a, b, c;
            a = 58 / 255;
            b = 156 / 255;
            c = 63 / 255;
            texto.text = "Unlocked";
            texto.color = new Color(a, b, c, 1);
        }
        else
        {
            float a, b, c;
            a = 165 / 255;
            b = 121 / 255;
            c = 27 / 255;
            texto.text = precio.ToString();
            texto.color = new Color(a, b, c, 1);
        }

    }

    private void OnMouseExit()
    {
        texto.text = "";
    }
}
