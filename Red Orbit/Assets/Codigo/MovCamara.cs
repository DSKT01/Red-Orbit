using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamara : MonoBehaviour {
    Transform mTrans;
    Transform jTrans;
    public float magnitud = 6;

	void Start () {
        mTrans = GetComponent<Transform>();
        jTrans = GameObject.Find("mona").GetComponent<Transform>();
	}
	
	
	void Update () {
        float newx = (Mathf.Abs(jTrans.position.x)+((Input.mousePosition.x)- (Camera.main.pixelWidth/2))/ (Camera.main.pixelWidth/magnitud)) /2;
        float newz = (Mathf.Abs(jTrans.position.z)+((Input.mousePosition.y)- (Camera.main.pixelHeight/ 2))/ (Camera.main.pixelHeight/magnitud)) /2;
        
        Vector3 posi = new Vector3 (newx,9f,newz-2f);
        mTrans.position = posi;        
        
	}
}
