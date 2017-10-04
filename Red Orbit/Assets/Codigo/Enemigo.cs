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
    public float retroceso = 0f;
    public float lifeE = 1;
    public float velocidad = 5f;
    public float daño = 1f;
    public float distanciaDe = 0f;
    bool c = true;
    ControlNiveles control;

    AudioSource mAudio;
    AudioClip[] aQuejidos;
    int num;

    // Use this for initialization
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Jugador").GetComponent<Transform>();
        mTransform = GetComponent<Transform>();
        control = GameObject.Find("Nivel").GetComponent<ControlNiveles>();

        mAudio = GetComponent<AudioSource>();
        aQuejidos = new AudioClip[] {Resources.Load("Audios/QuejidoEnemigo01") as AudioClip, 
            Resources.Load("Audios/QuejidoEnemigo02") as AudioClip,
            Resources.Load("Audios/QuejidoEnemigo03") as AudioClip,
            Resources.Load("Audios/QuejidoEnemigo04") as AudioClip};
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
                transform.LookAt(new Vector3(target.position.x, mTransform.position.y + 3, target.position.z));
            }
            if (lifeE <= 0)
            {
                
                if (c)
                {
                    control.contador++;
                    c = false;
                }
                Destroy(this.gameObject, 0.2f);
                
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
            Vector3 fuerza = mTransform.forward * retroceso * 1;
            jRigid.AddForce(fuerza);
            siguiendo = false;
            cj.Damage(1);

        }
        
        if (objeto.tag == "Bala")
        {
            Damage(1);
            

                  
        }
        

    }
    public void Damage (float x)
    {
        lifeE = lifeE - x;
    }
}


