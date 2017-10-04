using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo1 : MonoBehaviour
{

    Transform target;
    NavMeshAgent agente;
    public bool siguiendo = true;
    public float te = 2f;
    public float t = 0f;
    public float retroceso = 0f;
    public float lifeE = 1;
    public float velocidad = 5f;
    public float daño = 1f;
    // Use this for initialization
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Jugador").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()

    {
        if (!siguiendo)
        {
            t += Time.deltaTime;
            if (t >= te)
            {
                siguiendo = true;
                t = 0;
            }
        }
        else
        {
            agente.SetDestination(target.position);
        }
        
    }
    void OnCollisionEnter(Collision x)
    {
        GameObject jugador = x.gameObject;
        if (jugador.tag == "Player")
        {
            Rigidbody jRigid = jugador.GetComponent<Rigidbody>();
            siguiendo = false;
        }
    }
}


