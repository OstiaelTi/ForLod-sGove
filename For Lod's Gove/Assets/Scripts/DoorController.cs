using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

	public GameObject Door;
	public GameObject NoDoor;
	public Transform player;
	public GameObject camara;
	//public GameObject Giovanni;
	public bool playerInRoom;
	public int roomNumber;

	private Rigidbody2D rb2d;


	GiovanniControl Giovanni;
	RoomControllerScript controller;
	Quaternion rotation = Quaternion.Euler(0,0,90);

	void Awake(){
		controller = GameObject.FindObjectOfType<RoomControllerScript>();


		roomNumber = controller.roomNumber;

		if (controller.up)
			Instantiate(Door, new Vector3(transform.position.x , transform.position.y-22.4f), Quaternion.identity*rotation*rotation);
		else
			Instantiate(NoDoor, new Vector3(transform.position.x , transform.position.y-22.4f), Quaternion.identity*rotation*rotation);
		
		if (controller.right)
			Instantiate(Door, new Vector3(transform.position.x+28.8f , transform.position.y), Quaternion.identity*rotation*rotation*rotation);
		else
			Instantiate(NoDoor, new Vector3(transform.position.x+28.8f , transform.position.y), Quaternion.identity*rotation*rotation*rotation);
		
		if (controller.down)
			Instantiate(Door, new Vector3(transform.position.x , transform.position.y+22.4f), Quaternion.identity);
		else
			Instantiate(NoDoor, new Vector3(transform.position.x , transform.position.y+22.4f), Quaternion.identity);


		if (controller.left)
			Instantiate(Door, new Vector3(transform.position.x-28.8f , transform.position.y), Quaternion.identity*rotation);
		else
			Instantiate(NoDoor, new Vector3(transform.position.x-28.8f , transform.position.y), Quaternion.identity*rotation);
	}

	void Start(){
		
		camara = GameObject.FindGameObjectWithTag ("cam");
		Giovanni = GameObject.FindObjectOfType<GiovanniControl>();
		rb2d = GetComponent<Rigidbody2D>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update () {

		if (player.position.x > transform.position.x - 32 && player.position.x < transform.position.x + 32 && player.position.y > transform.position.y - 26.1 && player.position.y < transform.position.y + 26.1) {
			Giovanni.roomNumber = roomNumber;

			camara.transform.position  = new Vector3 (transform.position.x,transform.position.y,-50);

		}


	
	}
}
