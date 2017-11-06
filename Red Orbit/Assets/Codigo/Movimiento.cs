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
    public float dashCD;
    bool onCDSalto = false;     
    float tD = 0f;
    AudioSource mAudio;
    AudioClip aPasos, aSalto;
    bool enTierra = false;

    void Start()
    {
        mTransform = GetComponent<Transform>();
        mRigidbody = GetComponent<Rigidbody>();
        mAudio = GetComponent<AudioSource>();
        aPasos = Resources.Load("Audios/Pasos") as AudioClip;
        aSalto = Resources.Load("Audios/Salto") as AudioClip;

    }
    void Update()
    {

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
                                                                                

    public void Apuntar()
    {
        
        Transform dirApunte = GameObject.Find("Direccion").GetComponent<Transform>();
        mTransform.LookAt(dirApunte);
        
        

    }

    public void Salto()
    {
        if (onCDSalto)                 
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
            if (Input.GetButtonDown("Salto"))      
            {
                float xD = Input.GetAxis("Horizontal");
                float zD = Input.GetAxis("Vertical");

                Vector3 dirD;
                if (zD == 0 && xD == 0)
                {
                    dirD = new Vector3(mTransform.forward.x, 0, mTransform.forward.z);
                }
                else
                {
                    dirD = new Vector3(xD, 0, zD);
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
