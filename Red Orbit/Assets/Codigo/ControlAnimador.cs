using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ControlAnimador : MonoBehaviour
{
    Animator anim;
    [SerializeField]
    Transform targetR, targetL, cursor, direccion;
    Movimiento mMov;
    Vector3 actualPosition, lastPosition, delta;
    float actualPositionY, lastPositionY, deltaY;
    
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        mMov = GetComponent<Movimiento>();
    }
    
    // Update is called once per frame
    void Update()
    {

        //change
        anim.SetBool("Dir", Comparar());
        actualPositionY = transform.position.y;
        deltaY = Math.Abs (actualPositionY - lastPositionY);
        actualPosition = new Vector3(transform.position.x, 0, transform.position.z);
        delta = new Vector3(( Mathf.Ceil(Math.Abs((actualPosition.x * 2) - lastPosition.x))), 0, (Mathf.Ceil(Math.Abs(actualPosition.z * 2) - lastPosition.z)));
        if (deltaY == 0)
        {
            anim.SetInteger("Velocity", (int)(delta.x + delta.z));
        }
        else
        {
            anim.SetInteger("Velocity", 0);
        }
       // Debug.Log(delta);
        anim.SetBool("Dash", mMov.animacion);
    }
    void LateUpdate()
    {
        Almacen();
    }
    void OnAnimatorIK()
    {
        anim.SetLookAtWeight(1);
        anim.SetLookAtPosition(cursor.position);

        anim.SetIKPosition(AvatarIKGoal.LeftHand, targetL.position);
        anim.SetIKPosition(AvatarIKGoal.RightHand, targetR.position);
        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);

        anim.SetIKRotation(AvatarIKGoal.LeftHand, targetL.rotation);
        anim.SetIKRotation(AvatarIKGoal.RightHand, targetR.rotation);
        anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
        anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
    }
    void Almacen()
    {
        lastPosition = actualPosition;
        lastPositionY = actualPositionY;
    }
    bool Comparar()
    {
        bool dir;
        
        Vector3 c = cursor.position - transform.position;
        Vector3 a = new Vector3(Math.Abs(c.x), Math.Abs(c.y), Math.Abs(c.z));
        Vector3 b = direccion.localPosition - transform.position;
        Vector3 r = new Vector3(a.x * b.x , a.y * b.y , a.z * b.z );
        Vector3 f = new Vector3(Math.Abs(c.x - r.x), Math.Abs(c.y - r.y), Math.Abs(c.z - r.z));
        float mx = a.x * 1.8f;
        float mz = a.z * 1.8f;
        if ((b.x != 0) && (b.z != 0))
        {
            dir = Excepcion(b.normalized, c);
        }
        else
        {
            if ((f.x < mx) && (f.z < mz))
            {
                dir = true;
            }
            else
            {
                dir = false;
            }
            
        }
    
       // Debug.Log(dir);
       
        return dir;
    }
    bool Excepcion(Vector3 f, Vector3 fc)
    {
        bool z = false;
        float y = (-(f.x / f.z)) * fc.x;
        if  (f.z  > 0)
        {
            if (fc.z >= y)
            {
                z = true;
            }
            else
            {
                z = false;
            }
        }
        if (f.z < 0)
        {
            if (fc.z <= y)
            {
                z = true;
            }
            else
            {
                z = false;
            }
        }
        //Debug.Log(z);
        return z;
    }
}
