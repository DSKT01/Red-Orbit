using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ControlAnimador : MonoBehaviour
{
    Animator anim;
    [SerializeField]
    Transform targetR, targetL, cursor, direccion;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Comparar();

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
    void Comparar()
    {
        Vector3 c = cursor.position - transform.position;
        Vector3 a = new Vector3(Math.Abs(c.x), Math.Abs(c.y), Math.Abs(c.z));
        Vector3 b = direccion.localPosition - transform.position;
        Vector3 r = new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        Vector3 f = new Vector3(Math.Abs(c.x - r.x), Math.Abs(c.y - r.y), Math.Abs(c.z - r.z));
        Debug.Log(c + " c");
        Debug.Log(f + " f");
        Debug.Log(a + " a");
        Debug.Log(r + " r");
        Debug.Log(b + " b");
    }
}
