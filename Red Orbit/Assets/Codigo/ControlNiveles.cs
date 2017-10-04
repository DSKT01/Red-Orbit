using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlNiveles : MonoBehaviour {


    public int nivel;
    public int[] enemigos;
    public bool estado;
    public int contador;

  

	// Use this for initialization
	void Start () {
        enemigos = new int[3];
        enemigos[0] = 4;
        enemigos[1] = 8;
        enemigos[2] = 20;
        nivel = 1;
        contador = 0;
        estado = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (contador >= enemigos[nivel - 1])
        {
            nivel++;
            estado = true;
        }

        if (nivel==1 && estado)
        {
            GameObject Enemigo1;
            GameObject[] e1Clon = new GameObject[enemigos[0]];
            Enemigo1 = GameObject.Find("Enemigo");
            e1Clon[0] = Instantiate(Enemigo1, new Vector3(13f,10f,0f) , Quaternion.identity);
            e1Clon[1] = Instantiate(Enemigo1, new Vector3(-13f, 10f, 0f), Quaternion.identity);
            e1Clon[2] = Instantiate(Enemigo1, new Vector3(0f, 10f, 13f), Quaternion.identity);
            e1Clon[3] = Instantiate(Enemigo1, new Vector3(0f, 10f, -13f), Quaternion.identity);
            for (int i = 0; i < e1Clon.Length; i++)
            {
                Enemigo activar = e1Clon[i].GetComponent<Enemigo>();
                activar.activo = true;
            }
            contador = 0;
            estado = false;          
        }

        if (nivel == 2 && estado)
        {
            GameObject Enemigo1;
            GameObject[] e1Clon = new GameObject[enemigos[1]];
            Enemigo1 = GameObject.Find("Enemigo");
            e1Clon[0] = Instantiate(Enemigo1, new Vector3(13f, 10f, 0f), Quaternion.identity);
            e1Clon[1] = Instantiate(Enemigo1, new Vector3(-13f, 10f, 0f), Quaternion.identity);
            e1Clon[2] = Instantiate(Enemigo1, new Vector3(0f, 10f, 13f), Quaternion.identity);
            e1Clon[3] = Instantiate(Enemigo1, new Vector3(0f, 10f, -13f), Quaternion.identity);


            e1Clon[4] = Instantiate(Enemigo1, new Vector3(18f, 10f, 12f), Quaternion.identity);
            e1Clon[5] = Instantiate(Enemigo1, new Vector3(-18f, 10f, 12f), Quaternion.identity);
            e1Clon[6] = Instantiate(Enemigo1, new Vector3(18f, 10f, -12f), Quaternion.identity);
            e1Clon[7] = Instantiate(Enemigo1, new Vector3(-18f, 10f, -12f), Quaternion.identity);
            for (int i = 0; i < e1Clon.Length; i++)
            {
                Enemigo activar = e1Clon[i].GetComponent<Enemigo>();
                activar.activo = true;
            }
            contador = 0;
            estado = false;

        }

        if (nivel == 3 && estado)
        {
            GameObject Enemigo1;
            GameObject[] e1Clon = new GameObject[enemigos[2]];
            Enemigo1 = GameObject.Find("Enemigo");
            e1Clon[0] = Instantiate(Enemigo1, new Vector3(13f, 10f, 0f), Quaternion.identity);
            e1Clon[1] = Instantiate(Enemigo1, new Vector3(-13f, 10f, 0f), Quaternion.identity);
            e1Clon[2] = Instantiate(Enemigo1, new Vector3(0f, 10f, 13f), Quaternion.identity);
            e1Clon[3] = Instantiate(Enemigo1, new Vector3(0f, 10f, -13f), Quaternion.identity);


            e1Clon[4] = Instantiate(Enemigo1, new Vector3(18f, 10f, 12f), Quaternion.identity);
            e1Clon[5] = Instantiate(Enemigo1, new Vector3(-18f, 10f, 12f), Quaternion.identity);
            e1Clon[6] = Instantiate(Enemigo1, new Vector3(18f, 10f, -12f), Quaternion.identity);
            e1Clon[7] = Instantiate(Enemigo1, new Vector3(-18f, 10f, -12f), Quaternion.identity);

            e1Clon[8] = Instantiate(Enemigo1, new Vector3(10f, 10f, 0f), Quaternion.identity);
            e1Clon[9] = Instantiate(Enemigo1, new Vector3(-10f, 10f, 0f), Quaternion.identity);
            e1Clon[10] = Instantiate(Enemigo1, new Vector3(0f, 10f, 10f), Quaternion.identity);
            e1Clon[11] = Instantiate(Enemigo1, new Vector3(0f, 10f, -10f), Quaternion.identity);

            e1Clon[12] = Instantiate(Enemigo1, new Vector3(15f, 10f, 12f), Quaternion.identity);
            e1Clon[13] = Instantiate(Enemigo1, new Vector3(-15f, 10f, 12f), Quaternion.identity);
            e1Clon[14] = Instantiate(Enemigo1, new Vector3(15f, 10f, -12f), Quaternion.identity);
            e1Clon[15] = Instantiate(Enemigo1, new Vector3(-15f, 10f, -12f), Quaternion.identity);

            e1Clon[16] = Instantiate(Enemigo1, new Vector3(9f, 10f, 12f), Quaternion.identity);
            e1Clon[17] = Instantiate(Enemigo1, new Vector3(-9f, 10f, 12f), Quaternion.identity);
            e1Clon[18] = Instantiate(Enemigo1, new Vector3(9f, 10f, -12f), Quaternion.identity);
            e1Clon[19] = Instantiate(Enemigo1, new Vector3(-9f, 10f, -12f), Quaternion.identity);
            for (int i = 0; i < e1Clon.Length; i++)
            {
                Enemigo activar = e1Clon[i].GetComponent<Enemigo>();
                activar.activo = true;
            }
            contador = 0;
            estado = false;
        }

    }
}
