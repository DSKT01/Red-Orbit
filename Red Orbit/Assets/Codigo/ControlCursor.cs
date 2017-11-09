using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCursor : MonoBehaviour
{

    Transform jTrans;                                                                                                                                                                                                   // transform del jugador
    Vector3 player;                                                                                                                                                                                                        // se usara para registrar el delta del movimiento del jugador
    [SerializeField] 
    float maxDisX = 25;                                                                                                                                                                                               // distancia maxima del cursor en x al jugador
    [SerializeField]
    float maxDisZ = 10;                                                                                                                                                                                               // distancia maxima del cursor en z al jugador
    Transform cTrans, hTrans;
   
    void Start()
    {
        cTrans = GameObject.Find("PCamara").GetComponent<Transform>();
        jTrans = GameObject.Find("Jugador").GetComponent<Transform>();                                                                                     // acceso al transformador del jugador
        transform.position = new Vector3(jTrans.position.x, 2, jTrans.position.z);                                                                             // setear una posicion inicial para el cursor(especialmente en y)
        player = new Vector3(jTrans.position.x, 0, jTrans.position.z);                                                                                                       // setear una posicion inicial de "player" para calcular el delta de movimiento mas tarde
        hTrans = transform.Find("Marcador").transform;
    }


    void Update()
    {
        if (Time.timeScale == 1)                                                                                                                                                                                // verificar que el juego no este pausado
        {
            hTrans.LookAt(cTrans.position);
            hTrans.localPosition = new Vector3(0, 0, -10);
            Cursor.lockState = CursorLockMode.Locked;                                                                                                                                 // bloquear el puntero en el centro de la pantalla
            float mouseX = Input.GetAxis("Mouse X");                                                                                                                                       // input de del mouse en x (no depende de la posicion del puntero)
            float mouseZ = Input.GetAxis("Mouse Y");                                                                                                                                       // input de del mouse en x (no depende de la posicion del puntero)
            Vector3 mouse = new Vector3(Limite(mouseX, maxDisX, true), 0, Limite(mouseZ, maxDisZ, false));                   // vector usado para la velocidad de movimineto (se limita para que no se salga de la pantalla)(y es 0 para no alterar el movimiento en este eje)
            transform.position += mouse + Delta(player);                                                                                                                                // se mueve la posicion segun el input del mouse, "delta" permite moverse junto al personaje al sumar la cantidad de movimiento hecha por el personaje desde el frame anterior
            transform.position = new Vector3(transform.position.x, jTrans.position.y + 1.81f, transform.position.z);          // para mantener la poscion en el eje y igual a la del arma del jugador
            player = new Vector3(jTrans.position.x, 0, jTrans.position.z);                                                                                                  // se almacenan los valores de player al final para que "delta" trabaje con los datos anteriores (y es 0 para no alterar el movimiento en este eje)

        }

        else
        {
            Cursor.lockState = CursorLockMode.None;                                                                                                                                    // si esta pausado desbloquea el puntero del centro de la pantalla
        }
    }
    Vector3 Delta(Vector3 x)                                                                                                                                                                                  // "x" sera la posicion anterior. ingresaran los datos de player para hallar la diferencia entre la posicion anterior y la actual
    {
        Vector3 y = new Vector3(jTrans.position.x, 0, jTrans.position.z);                                                                                               // posicion actual del personaje (y es 0 para no alterar el movimiento en este eje)
        Vector3 z = y - x;                                                                                                                                                                                              //diferencia entre el anterior frame y el actual (delta) se guarda en "z"
        return z; 
    }
    float Limite(float x, float y, bool b  )                                                                                                                                                           // "b" verificara en que eje se quiere trabajar, "y" es la distncia maxima que alcanzara en el eje, "x" movimiento del mouse. se limitara un eje para no salirse de la pantalla
    {

        float z = x;                                                                                                                                                                                                          // "z" sera la variable de retorno(comenzara por defecto igual a la entrada, asi, si no se dice lo contrario, "mouse" seguira funcionando sin modificaciones, de lo contrario se limitara
        float j, d, m, w;                                                                                                                                                                                                // "j" posicion del jugador en eje especificado, "d" delta de la posicion del jugador en eje especificado, "m" posicion propia en eje especificado, "w" se especifica despues
        if (b)                                                                                                                                                                                                                     //******************************** segun el valor de "b" se elije un eje ********************************
        {
            j = jTrans.position.x;
            d = Delta(player).x;
            m = transform.position.x;
        }
        else
        {
            j = jTrans.position.z;
            d = Delta(player).z;
            m = transform.position.z;
        }                                                                                                                                                                                                                              //********************************                ********************************
        w = Mathf.Abs(j - (x + m + d));                                                                                                                                                                   // se predice en donde quedara el puntero en el paso actual (antes de ejecutarlo)(pos del jugador menos la suma de la pos propia, el movimiento del mouse y el delta de movimiento del jugador
        if (w >= y)                                                                                                                                                                                                            // verifica si la prediccion supera el limite
        {
            z = 0;                                                                                                                                                                                                                 // si lo supera iguala z a 0 y al devolverlo el vector de "mouse" quedara en 0 y no habra movimiento en ese eje
        }
        return z;                                                                                                                                                                                                              // retorna "z"
    }
}
