using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropLaser : MonoBehaviour {

    Proyectil proyComp;
    Rigidbody mCuerpo;
    Vector3 p;
    Quaternion r;
    public float duracionMax;
    float t = 0;

	void Start () {
        proyComp = GetComponent<Proyectil>();
        mCuerpo = GetComponent<Rigidbody>();
        p = transform.position;
        r = transform.rotation;
	}
	
	void Update () {
        t += Time.deltaTime;
        if (t >= duracionMax)
        {
            Reaparecer();
            t = 0;
        }

        if (proyComp.enPiscina)
        {
            mCuerpo.velocity = new Vector3(0, 0, 0);
        }
	}

    void OnCollisionEnter(Collision _x)
    {
        t = 0;
        GameObject obj = _x.gameObject;
        if (obj.tag == "Enemigo")
        {
            Reaparecer();
        }
        
    }

    void Reaparecer()
    {
        transform.position = p;
        transform.rotation = r;
        proyComp.disparable = true;
        proyComp.enPiscina = true;
    }
}
