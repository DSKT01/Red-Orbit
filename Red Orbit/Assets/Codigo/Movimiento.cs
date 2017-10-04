using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
  
    [SerializeField]
    float mag;
    [SerializeField]
    float magD;
    Transform mTransform;
    Rigidbody mRigidbody;
    Transform cTransform;
    public float dashCD;
    bool onCDSalto = false;     
    float tD = 0f;
    Transform aTransform;
    Vector3 dirMov;

    AudioSource mAudio;
    AudioClip aPasos, aSalto;
    bool enTierra = false;

    void Start()
    {
        mTransform = GetComponent<Transform>();
        mRigidbody = GetComponent<Rigidbody>();
        cTransform = GameObject.Find("PCamara").GetComponent<Transform>();
        aTransform = GameObject.Find("ArmaCube").GetComponent<Transform>();

        mAudio = GetComponent<AudioSource>();
        aPasos = Resources.Load("Audios/Pasos") as AudioClip;
        aSalto = Resources.Load("Audios/Salto") as AudioClip;

    }
    void Update()
    {
        Debug.Log(enTierra);
    }
    public void HMove()
    {
        float x = (Mathf.Abs(2 - mTransform.position.y));
        if (x < 0.8)
        {
            x = 0;
        }
        float y = 2 / (2 + x);
        //movimiento vertical
        Vector3 dirV = new Vector3(0, 0, 1);
        float senV = Input.GetAxis("Vertical");
        Vector3 VelocidadV = senV * dirV * mag * y;
        mTransform.position += VelocidadV * Time.deltaTime;

        //movimiento horizontal
        Vector3 dirH = new Vector3(1, 0, 0);
        float senH = Input.GetAxis("Horizontal");
        Vector3 VelocidadH = senH * dirH * mag * y;
        mTransform.position += VelocidadH * Time.deltaTime;
        mTransform.up = new Vector3(0, 1, 0);
        
    }
                                                                                //Pendiente: Separar cuerpo con cabeza/arma

    public void Apuntar()
    {
        //direccion del personaje dictada por el mouse
        
        float distanciaECYP = Vector3.Distance(cTransform.position, mTransform.position);
        Ray Rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 ubicacionM = Rayo.GetPoint(distanciaECYP);
        Vector3 puntero = new Vector3(ubicacionM.x, mTransform.position.y, ubicacionM.z);
        mTransform.LookAt(puntero);
        
        

    }

    public void Salto()
    {
        if (onCDSalto)                  //  Aquí no salta!
        {
            tD += Time.deltaTime;
            if (tD >= dashCD)
            {
                onCDSalto = false;
                tD = 0;
            }
        }
        if (!onCDSalto)
        {
            if (Input.GetButtonDown("Salto"))       //  Aquí salta!
            {
                float xD = Input.GetAxis("Horizontal");
                float zD = Input.GetAxis("Vertical");

                Vector3 dirD;
                if (zD == 0 && xD == 0)
                {
                    dirD = new Vector3(mTransform.forward.x, 1, mTransform.forward.z);
                }
                else
                {
                    dirD = new Vector3(xD, 1, zD);
                }
                float senD = 1f;
                Vector3 fuerzaD = dirD * magD * senD;
                mRigidbody.AddForce(fuerzaD);

                onCDSalto = true;
            }
        }

    }

    public void Sonar()
    {
        #region Pasos
        if (Input.GetAxis("Horizontal") != 0 ||
            Input.GetAxis("Vertical") != 0)
        {
            // Reproducir sonido de pasos
            mAudio.clip = aPasos;
            if (!mAudio.isPlaying)
            {
                if (enTierra)
                    mAudio.Play();
            }
            mAudio.loop = true;
        }
        else
        {
           if (mAudio.isPlaying)   // Detener el aPasos si no se está moviendo.
            {
                if (mAudio.clip != aSalto)  //Comparar el clip de Audio.
                    mAudio.Stop();
            }
        }
        #endregion

        if (!enTierra)
        {
            
        }
    }

    void OnCollisionEnter (Collision _colision)
    {
        GameObject objeto = _colision.gameObject;
        if (objeto.tag == "Terreno")
            enTierra = true;
    }
    void OnCollisionExit(Collision _colision)
    {
        GameObject objeto = _colision.gameObject;
        if (objeto.tag == "Terreno")
        {
            enTierra = false;
            mAudio.clip = aSalto;
            mAudio.loop = false;
            mAudio.Play();
        }
            

    }

}
