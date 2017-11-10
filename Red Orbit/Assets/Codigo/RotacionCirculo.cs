using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionCirculo : MonoBehaviour {
    float a, t;
    Vector3 v;
    [SerializeField]
    ControlJugador player;
    Transform playerObj;
    // Use this for initialization
    void Start () {
        t = Random.Range(1, 5);
        if (player != null)
        {
            playerObj = player.gameObject.transform;
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        a = (Mathf.Sin(t/2) + 2) * Time.deltaTime * 50;
        v = new Vector3(0, a, 0);
        transform.eulerAngles += v;
        if (player != null)
        {
            if (playerObj.position.y < transform.position.y)
            {
                player.Damage(1);
            }
        }
        
    }
}
