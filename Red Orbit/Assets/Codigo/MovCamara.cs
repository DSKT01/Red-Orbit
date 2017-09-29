using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamara : MonoBehaviour {
    Transform mTrans;
    Transform jTrans;
    public float magnitud = 6;

	void Start () {
        mTrans = GetComponent<Transform>();
        //cambiar "mona" por player
        jTrans = GameObject.Find("mona").GetComponent<Transform>();
	}
	
	
	void Update () {

        float distancia = Vector3.Distance(mTrans.position,jTrans.position)/(1.1f);
        Ray Rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 ubicacionM = Rayo.GetPoint(distancia);
        Vector3 puntero = new Vector3(ubicacionM.x,mTrans.position.y, ubicacionM.z);

        Vector3 posi = (puntero + jTrans.position) / 2;

        mTrans.position = new Vector3 (posi.x,12,posi.z-4) ;
    }
}
