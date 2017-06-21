using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextZone : MonoBehaviour {

	public GameObject Door;

	void Start () {
		Instantiate (Door, new Vector3(transform.position.x, transform.position.y+5,0), Quaternion.identity);
	}

}
