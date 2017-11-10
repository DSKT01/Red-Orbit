using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    int d;

   
    // Use this for initialization
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision x)
    {
        GameObject obj = x.gameObject;
        if (obj.tag == "Player")
        {
            ControlJugador jugador = obj.GetComponent<ControlJugador>();
            jugador.Damage(d);
        }

        
        if (obj.tag == "Enemigo")
        {
            Enemigo enemigo = obj.GetComponent<Enemigo>();
            enemigo.Damage(d);
        }
    }
}
