using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espawn : MonoBehaviour
{
    public int lim;
    public int actuales = 0;
    float temporizador = 30;
    public int alarma = 30;
    float temporizador2 = 0;
    public int alarma2 = 1;
    GameObject enemigos;
    public int numEn = 0;
    public float numEnTo = 5;
    public Transform[] posiciones = new Transform[4];
    // Use this for initialization
    void Start()
    {
        enemigos = GameObject.Find("Poio");
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
        Debug.Log(actuales);
    }
    void Esperar()
    {
        temporizador2 += Time.deltaTime;
        if (temporizador2 >= alarma2)
        {
            if (actuales <= lim)
            {
                Spawn();
            }       
            numEn++;
            temporizador2 = 0;
        }
    }
    void Spawn()
    {
        GameObject clon = Instantiate(enemigos, posiciones[Random.Range(0,4)].transform.position, Quaternion.identity);
        actuales++;
        Enemigo clonComp = clon.GetComponent<Enemigo>();
        clonComp.activo = true;
        clonComp.siguiendo = true;
        clonComp.lifeE = Random.Range(1, 6);
        Renderer[] cRender = clonComp.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < cRender.Length; i++)
        {
            cRender[i].material.color = new Color((1 / Random.Range(1, 5)), (1 / Random.Range(1, 5)), (1 / Random.Range(1, 5)), 1);
        }
        clonComp.velocidad = Random.Range(4, 11);
        clonComp.daño = Random.Range(1, 3);
    }
}
