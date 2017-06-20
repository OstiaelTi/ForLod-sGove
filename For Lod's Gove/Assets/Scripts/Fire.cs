using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
    GiovanniStats giovannistats;
    GiovanniControl giovannicontrol;


    // Use this for initialization
    void Start () {
        giovannicontrol = GameObject.FindObjectOfType<GiovanniControl>();
        giovannistats = GameObject.FindObjectOfType<GiovanniStats>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(giovannicontrol.transform.position.x - transform.position.x) < 2.5 && Mathf.Abs(giovannicontrol.transform.position.y - transform.position.y) < 3)
        {
            giovannistats.isDead = true;
        }
    }
}
