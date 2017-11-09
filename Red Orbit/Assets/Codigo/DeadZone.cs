using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour {
    [SerializeField]
    int d;
    [SerializeField]
    ControlJugador player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player.gameObject.transform.position.y < transform.position.y)
        {
            player.Damage(1);
        }
	}
    void OnCollisionEnter (Collision x)
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
