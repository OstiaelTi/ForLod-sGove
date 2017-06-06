using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

	public GameObject Door;
	public GameObject Giovanni;
	public bool playerInRoom;

	RoomControllerScript controller;
	Quaternion rotation = Quaternion.Euler(0,0,90);

	void Awake(){
		controller = GameObject.FindObjectOfType<RoomControllerScript>();


		if (controller.up)
			Instantiate(Door, new Vector3(transform.position.x , transform.position.y-22.4f), Quaternion.identity*rotation*rotation);
		if (controller.right)
			Instantiate(Door, new Vector3(transform.position.x+28.8f , transform.position.y), Quaternion.identity*rotation*rotation*rotation);
		if (controller.down)
			Instantiate(Door, new Vector3(transform.position.x , transform.position.y+22.4f), Quaternion.identity);
		if (controller.left)
			Instantiate(Door, new Vector3(transform.position.x-28.8f , transform.position.y), Quaternion.identity*rotation);
	}

	void Start(){
		Giovanni = GameObject.FindGameObjectWithTag("Player");
	}

	void Update () {

		if (Giovanni.transform.position.x > transform.position.x - 32 && Giovanni.transform.position.x < transform.position.x + 32 && Giovanni.transform.position.y > transform.position.y - 26.1 && Giovanni.transform.position.y < transform.position.y + 26.1)
			playerInRoom = true;
		else
			playerInRoom = false;
	}
}
