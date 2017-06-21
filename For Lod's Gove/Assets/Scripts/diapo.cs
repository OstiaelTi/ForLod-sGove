using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diapo : MonoBehaviour {
	public GameObject next;

	void Start () {
		
	}

	void Update () {

		if (Input.GetKeyDown ("j")) {
			Instantiate (next, new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity);
			Destroy (this);
		}
	
}
}
