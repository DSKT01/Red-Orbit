using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLuces : MonoBehaviour
{
    Transform mTransform;
    float t = 0;
    // Use this for initialization
    void Start()
    {
        mTransform = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        transform.LookAt(new Vector3(0, 0, Mathf.Sin(t)));
       
    }
}
