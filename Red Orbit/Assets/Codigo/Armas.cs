﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Armas : MonoBehaviour {
    Variables variables;
    public Text texto;
    int precio=450;
    public Sprite spr1;
    public Sprite spr2;
    SpriteRenderer sprite;

    // Use this for initialization
    void Start () {
        sprite = GetComponent<SpriteRenderer>();
        variables = GameObject.Find("Variables").GetComponent<Variables>();
    }
	
	// Update is called once per frame
	void Update () {
  
    }
    private void OnMouseDown()
    {
        if (variables.monedas > precio && variables.armas == 2)
        {
            variables.armas++;
            variables.monedas -= precio;
            sprite.sprite = spr2;
        }
        if (variables.monedas> precio && variables.armas == 1)
        {
            variables.armas++;
            variables.monedas -= precio;
            sprite.sprite = spr1;
            precio = 1000;
        }

    }

    private void OnMouseOver()
    {

        texto.rectTransform.position = Input.mousePosition;
        if (variables.armas == 3)
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
