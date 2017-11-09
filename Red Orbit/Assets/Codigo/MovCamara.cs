using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamara : MonoBehaviour
{

    Transform pTrans;
    Transform jTrans;

    void Start()
    {
       
        pTrans = GameObject.Find("Cursor").GetComponent<Transform>();
        jTrans = GameObject.Find("Jugador").GetComponent<Transform>();
    }


    void Update()
    {
        
        Vector3 posi = (pTrans.position + jTrans.position) / 2;
        Vector3 posiF = new Vector3(posi.x, jTrans.position.y + 15, posi.z - 14f);
        float x = ((Vector3.Distance(transform.position, posiF)) / 2) * 30f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, posiF, x);
      
    }
    


}
