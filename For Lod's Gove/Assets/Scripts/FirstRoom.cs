using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstRoom : MonoBehaviour{


	public GameObject Player;
	public GameObject Camera;

    

    // Use this for initialization
    void Awake () {
	    Instantiate (Player, transform.position, Quaternion.identity);
		Instantiate(Camera, new Vector3(transform.position.x, transform.position.y, -50), Quaternion.identity);

       

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
