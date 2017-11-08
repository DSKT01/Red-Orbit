using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Permanente : MonoBehaviour {

    static Permanente perma;

    // Use this for initialization
    void Start()
    {
        if (perma != null)
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(gameObject);
            perma = this;
        }
    }
}
