using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropBombas : MonoBehaviour {

    Rigidbody mCuerpo;
    Proyectil proyComp;
    Vector3 p;
    Quaternion r;
    public float duracionMax, 
        radio,
        mag,
        up;
    float t = 0;
    Collider[] colliders;

    // Use this for initialization
    void Start () {
        proyComp = GetComponent<Proyectil>();
        mCuerpo = GetComponent<Rigidbody>();
        p = transform.position;
        r = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        if (t >= duracionMax)
        {
            Explotar();
            t = 0;
        }
        if (proyComp.enPiscina)
        {
            mCuerpo.Sleep();
            mCuerpo.velocity = new Vector3(0, 0, 0);
        }
    }

    void OnCollisionEnter (Collision _x)
    {
        if(_x.gameObject.tag == "Enemigo" || _x.gameObject.tag == "Terreno")
        {
            Explotar();
        }
    }

    void Explotar()
    {
        if (!proyComp.enPiscina)
        {
            colliders = Physics.OverlapSphere(transform.position, radio);
            foreach (Collider collider in colliders)
            {
                GameObject a = collider.gameObject;
                if (a.tag == "Enemigo")
                {
                    a.GetComponent<Enemigo>().Damage(proyComp.daño);
                }

                if (collider.GetComponent<Rigidbody>() != null)
                {
                    Rigidbody b = collider.GetComponent<Rigidbody>();
                    b.AddExplosionForce(mag, transform.position, radio, up, ForceMode.Acceleration);
                }
            }

            Debug.Log("uy, exploté!");
            transform.position = p;
            transform.rotation = r;
            proyComp.enPiscina = true;
            proyComp.disparable = true;
        }
    }

}
