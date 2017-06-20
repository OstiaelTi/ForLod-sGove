using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public GameObject Diablillo;
	public GameObject Gordo;
	public GameObject Fantasma;
	public int zona;

	// Use this for initialization
	void Awake () 
	{
		float s = Random.Range (0, 3);
		int sw = (int)s;
		switch (sw) {
		case 0:
			Instantiate (Diablillo, new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
		break;
		case 1: 
			Instantiate (Gordo, new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
			break;
		case 2: 
			Instantiate (Fantasma, new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
			break;

		default: 
			Instantiate (Diablillo, new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
			break;
		
		
	}
	}
	// Update is called once per frame
	
}
