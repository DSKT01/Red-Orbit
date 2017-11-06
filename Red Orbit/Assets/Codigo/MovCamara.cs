using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamara : MonoBehaviour
{
    /*
    SeleccionPJ seleccion;
    Transform pTrans;
    Transform mTrans;
    Transform sTrans;
    Transform jTrans;
    Texture2D puntero;
    */
    Transform pTrans;
    Transform jTrans;

    void Start()
    {
        /*
        mTrans = GetComponent<Transform>();
        jTrans = GameObject.Find("Jugador").GetComponent<Transform>();
        puntero = Resources.Load("Texturas/Puntero") as Texture2D;
        sTrans = GameObject.Find("SeleccionDePersonaje").GetComponent<Transform>();
        seleccion = GameObject.Find("SeleccionDePersonaje").GetComponent<SeleccionPJ>();
        pTrans = GameObject.Find("Cursor").GetComponent<Transform>();
        */
        pTrans = GameObject.Find("Cursor").GetComponent<Transform>();
        jTrans = GameObject.Find("Jugador").GetComponent<Transform>();
    }


    void Update()
    {
        
        Vector3 posi = (pTrans.position + jTrans.position) / 2;
        Vector3 posiF = new Vector3(posi.x, jTrans.position.y + 10, posi.z - 10f);
        float x = ((Vector3.Distance(transform.position, posiF)) / 2) * 30f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, posiF, x);
        /*
         if (seleccion.seleccionPJ == true)
         {
             Rect Pantalla = new Rect(15, 15, Screen.width-15, Screen.height-15);
            if (Pantalla.Contains(Input.mousePosition))
             {
                 Cursor.SetCursor(puntero, new Vector3(16, 16), CursorMode.Auto);
                 if (Time.timeScale == 0)
                 {
                     Cursor.visible = true;
                 }
                 else
                 {
                     Cursor.visible = false;

                 }

                 float distancia = Vector3.Distance(mTrans.position, jTrans.position) * 0.9f;
                 Ray RayoA = Camera.main.ScreenPointToRay(Input.mousePosition);
                 Vector3 ubicacionM = new Vector3  (RayoA.GetPoint(distancia).x, jTrans.position.y, RayoA.GetPoint(distancia).z) ;             
                 Vector3 posi = (ubicacionM + jTrans.position) / 2;
                 Vector3 posiF = new Vector3(posi.x, jTrans.position.y + 9.9f, posi.z - 6.88f);
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
         else
         {
             Rect Pantalla = new Rect(0, 0, Screen.width, Screen.height);
             Vector3 posiFs = new Vector3(sTrans.position.x, sTrans.position.y + 9.9f, sTrans.position.z - 6.88f);
             mTrans.position = posiFs;

             if (Pantalla.Contains(Input.mousePosition))
             {

                 Cursor.SetCursor(puntero, new Vector2(16, 16), CursorMode.Auto);
             }
             else
             {
                 Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
             }

         }
         */
    }
    


}
