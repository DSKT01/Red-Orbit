﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espawn : MonoBehaviour
{
    float temporizador = 30;
    public int alarma = 30;
    float temporizador2 = 0;
    public int alarma2 = 1;
    GameObject enemigos;
    public int numEn = 0;
    public float numEnTo = 5;
    public Transform[] posiciones=new Transform[4];
    // Use this for initialization
    void Start()
    {
        enemigos = GameObject.Find("Enemigo");
    }

    // Update is called once per frame
    void Update()
    {
        temporizador += Time.deltaTime;
        if (temporizador >= alarma)
        {
            if (numEn < numEnTo)
            {
                Esperar();
            }
            else
            {
                numEnTo += Mathf.Log(numEnTo,1.8f);
                numEn = 0;
                temporizador = 0;
            }
        }
    }
    void Esperar()
    {
        temporizador2 += Time.deltaTime;
        if (temporizador2 >= alarma2)
        {
            Spawn();
            numEn++;
            temporizador2 = 0;
        }
    }
    void Spawn()
    {
        Instantiate(enemigos, posiciones[Random.Range(0,4)].transform);
    }
}
