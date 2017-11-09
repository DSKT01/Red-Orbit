using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    Transform mTransform;
    Transform target;
    NavMeshAgent agente;
    public bool activo = false;
    public bool siguiendo = true;
    public float te = 2f;
    public float t = 0f;

    public float lifeE = 1;
    public float velocidad = 5f;
    public float daño = 1f;
    public float distanciaDe = 0f;
    bool c = true;
    Variables variables;
    Espawn capEnemigos;

  
    int num;

    // Use this for initialization
    void Start()
    {
        variables = GameObject.Find("Variables").GetComponent<Variables>();
        agente = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Jugador").GetComponent<Transform>();
        mTransform = GetComponent<Transform>();
        capEnemigos = GameObject.Find("Spawn").GetComponent<Espawn>();

    } 

    // Update is called once per frame
    void Update()

    {
        
        if (activo)
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
                agente.speed = velocidad;
                agente.stoppingDistance = distanciaDe;
                transform.LookAt(new Vector3(target.position.x, mTransform.position.y, target.position.z));
            }
            if (lifeE <= 0)
            {
                variables.muertes++;
                variables.monedas += ((Random.Range(3, 10)) * variables.mMonedas);
                capEnemigos.actuales--;
                Destroy(this.gameObject);
                
            }
        }
        
        
    }
    void OnCollisionEnter(Collision x)
    {
        GameObject objeto = x.gameObject;

        if (objeto.tag == "Player")
        {
            ControlJugador cj = objeto.GetComponent<ControlJugador>();
            Rigidbody jRigid = objeto.GetComponent<Rigidbody>();

            siguiendo = false;
            cj.Damage(daño);

        }
        
        if (objeto.tag == "Bala")
        {
            Proyectil magDamage = objeto.GetComponent<Proyectil>();
            Damage(magDamage.daño);      
        }
        

    }
    public void Damage (float x)
    {
        lifeE = lifeE - x;
    }
}


