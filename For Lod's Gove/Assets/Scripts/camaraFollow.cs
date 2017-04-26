using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraFollow : MonoBehaviour {

	public Transform target;
	public float moveSpeed;
	public float zPosition;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	// Update is called once per frame
	void Update () {
		/*float moduloVector = Mathf.Sqrt(Mathf.Pow(target.position.x - transform.position.x, 2) + Mathf.Pow(target.position.y - transform.position.y, 2));

		float unitari_x = (target.position.x - transform.position.x) / moduloVector;
		float unitari_y = (target.position.y - transform.position.y) / moduloVector;

		transform.position = new Vector3(
			unitari_x * moveSpeed + transform.position.x,
			unitari_y * moveSpeed + transform.position.y, zPosition
		);*/
	}
}