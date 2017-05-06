using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstRoom : MonoBehaviour{


	public GameObject Player;
    

    // Use this for initialization
    void Start () {
	    Instantiate (Player, transform.position, Quaternion.identity);

       

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
