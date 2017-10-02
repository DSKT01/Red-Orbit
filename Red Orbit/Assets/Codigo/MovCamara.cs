using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamara : MonoBehaviour
{
    Transform mTrans;
    Transform jTrans;
    Texture2D puntero;
    void Start()
    {
        mTrans = GetComponent<Transform>();
        //cambiar "mona" por player
        jTrans = GameObject.Find("Jugador").GetComponent<Transform>();
        puntero = Resources.Load("Texturas/Puntero") as Texture2D;
    }


    void Update()
    {
        Rect Pantalla = new Rect(0, 0, Screen.width, Screen.height);
        if (Pantalla.Contains(Input.mousePosition))
        {
            Cursor.SetCursor(puntero, new Vector3 (16, 16) , CursorMode.Auto);
            float distancia = Vector3.Distance(mTrans.position, jTrans.position) * 0.9f;
            Ray Rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 ubicacionM = Rayo.GetPoint(distancia);
            Vector3 posi = (ubicacionM + jTrans.position) / 2;
            Vector3 posiF = new Vector3(posi.x,jTrans.position.y + 9.9f, posi.z - 6.88f); 
            float x = ((Vector3.Distance(mTrans.position, posiF)) / 2) * 30f * Time.deltaTime;
            mTrans.position = Vector3.MoveTowards(mTrans.position, posiF, x);
        }
        else
        {
            Vector3 posiFs = new Vector3(jTrans.position.x, jTrans.position.y + 9.9f, jTrans.position.z - 6.88f);
            float y = ((Vector3.Distance(mTrans.position, posiFs)) / 2) * 3 * Time.deltaTime;
            mTrans.position = Vector3.MoveTowards(mTrans.position, posiFs, y);

            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
        

    }
  
  
}
