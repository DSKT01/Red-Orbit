using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{

    /*LAS BALAS SE DESTRUIRÁN DESPUES DE 3 SEGUNDOS DE HABER TOCADO EL PISO, LUEGO CUANDO 
     *HABLEMOS DE DIFERENTES TIPOS DE PROYECTILES CAMBIAMOS LO QUE SEA NECESARIO.
     */

    [SerializeField]
    float magnitud;     // Fuerza de lanzamiento de la bala.

    Rigidbody mCuerpo;
    Transform trArma;   // Toma el transform del arma para que la dirección del lanzamiento sea a la cual se está apuntando.

    [SerializeField]
    float duración, contador;       // Tiempo para que la bala desaparesca.

    public bool disparado;
    bool colisiono;     // Si colisionó o no contra el piso.

    AudioSource mAudio;

    // Use this for initialization
    void Start()
    {

        //Salir disparadas al ser creadas.
        mCuerpo = GetComponent<Rigidbody>();
        trArma = GameObject.Find("ArmaCube").GetComponent<Transform>();  // CAMBIAR ARMACUBE POR EL NOMBRE DEL ARMA

        mCuerpo.AddForce(trArma.forward * magnitud);   //salir disparado.

        colisiono = false;

        mAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        Destruirse();
    }

    void OnCollisionEnter(Collision _piso)
    {
        GameObject piso = _piso.gameObject;
        if (piso.tag == "Terreno")
        {
            Destroy(this.gameObject);
        }
        if (piso.tag == "Enemigo")
        {
            
            Destroy(this.gameObject);
        }
    }

    void Destruirse()
    {
        if (disparado == true)
        {

            contador += Time.deltaTime;

            if (contador > duración)
                Destroy(this.gameObject);
            
        }


    }
}
